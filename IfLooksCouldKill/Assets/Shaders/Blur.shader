Shader "Custom/Blur"
{
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Radius("Radius", Range(1, 1280)) = 1
    }
    
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 uv_grab : TEXCOORD0;
			float4 proj;
			float4 screenPos;
		};

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float _Radius;

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o) {
            float2 coords = IN.screenPos.xy / IN.screenPos.w; //These coords are 0 to 1
			coords.x = (coords.x - 0.5) * 1280 * 2; //This puts them in -1280 to 1280
			coords.y = (coords.y - 0.5) * 720 * 2; //ditto for 720
			float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			if ((coords.x * coords.x) + (coords.y * coords.y) >=  (_Radius * _Radius)) {
				float2 offset = 1.0 / _ScreenParams.xy; 
				c += tex2D(_MainTex, IN.uv_MainTex + float2(offset.x, offset.y)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(-offset.x, offset.y)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(-offset.x, -offset.y)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(offset.x, -offset.y)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(offset.x, 0.0)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(-offset.x, 0.0)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(0.0, offset.y)) * _Color;
				c += tex2D(_MainTex, IN.uv_MainTex + float2(0.0, -offset.y)) * _Color;
				c /= 9;
			}
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
