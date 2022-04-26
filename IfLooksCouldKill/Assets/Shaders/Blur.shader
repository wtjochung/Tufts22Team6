Shader "Custom/Blur" {
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Radius("Radius", Range(1, 100)) = 1
		_Intensity("Intensity", Range(1, 100)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;
			};

			sampler2D _MainTex;
			half _Radius;
			int _Intensity;

			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target {
				float2 coords = ((i.screenPos.xy / i.screenPos.w) - 0.5) * (128, 72);
				half4 col = tex2D(_MainTex, i.uv);
				fixed radius_diff = (((coords.x * coords.x) + (coords.y * coords.y))
				 - (_Radius * _Radius)); //Full disclosure I have no idea what scale these coords are
				 //I'm just throwing numbers at it until it works
				if (radius_diff >= 0.0) {
					for (int idx = 0; idx < _Intensity && idx < 100; idx++) {
						float2 offset = (((radius_diff / (128, 72)) * (float)idx) / _ScreenParams.xy);
						col += tex2D(_MainTex, i.uv + float2(offset.x, offset.y));
						col += tex2D(_MainTex, i.uv + float2(-offset.x, offset.y));
						col += tex2D(_MainTex, i.uv + float2(-offset.x, -offset.y));
						col += tex2D(_MainTex, i.uv + float2(offset.x, -offset.y));
						col += tex2D(_MainTex, i.uv + float2(offset.x, 0.0));
						col += tex2D(_MainTex, i.uv + float2(-offset.x, 0.0));
						col += tex2D(_MainTex, i.uv + float2(0.0, offset.y));
						col += tex2D(_MainTex, i.uv + float2(0.0, -offset.y));
					}
					col /= (8 * _Intensity) + 1;
				}
				return col;
			}
			ENDCG
		}
	}
}
