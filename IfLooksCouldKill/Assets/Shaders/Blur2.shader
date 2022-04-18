Shader "Custom/Blur2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Radius("Radius", Range(1, 100)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
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
			float _Radius;

			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target {
				float2 coords = i.screenPos.xy / i.screenPos.w; //These coords are 0 to 1
				coords.x = (coords.x - 0.5) * 128; //This puts them in -100 to 100
				coords.y = (coords.y - 0.5) * 72;
				float4 col = tex2D(_MainTex, i.uv);
				float circle_coord = (coords.x * coords.x) + (coords.y * coords.y);
				if (circle_coord >= _Radius * _Radius) {
					float2 offset = 5.0 / _ScreenParams.xy;
					col += tex2D(_MainTex, i.uv + float2(offset.x, offset.y));
					col += tex2D(_MainTex, i.uv + float2(-offset.x, offset.y));
					col += tex2D(_MainTex, i.uv + float2(-offset.x, -offset.y));
					col += tex2D(_MainTex, i.uv + float2(offset.x, -offset.y));
					col += tex2D(_MainTex, i.uv + float2(offset.x, 0.0));
					col += tex2D(_MainTex, i.uv + float2(-offset.x, 0.0));
					col += tex2D(_MainTex, i.uv + float2(0.0, offset.y));
					col += tex2D(_MainTex, i.uv + float2(0.0, -offset.y));
					col /= 9;
				}
				return col;
			}
			ENDCG
		}
	}
}
