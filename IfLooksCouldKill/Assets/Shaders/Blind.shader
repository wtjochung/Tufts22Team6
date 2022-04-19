// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//Note: The comments in this code are designed to make sure I know what this is doing in glsl terms that I can understand.
//If they make no sense bc you don't know glsl, just lmk and I can explain it - Henry

Shader "Custom/Blind" {
	Properties { //This is how uniform vars are accessed from the Unity editor
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}

	SubShader {
		Tags { "RenderType"="Transparent" }
		LOD 200 

		CGPROGRAM

		//misc render settings
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;

		//This is where uniform vars are actually declared

		struct Input {
			float2 uv_MainTex;
			float4 uv_grab : TEXCOORD0;
			float4 proj;
			float4 screenPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		uniform int _Blind;

		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		//Essentially the shader's main function. This modifies the data sent to the REAL frag shader that renders each object.
		void surf (Input IN, inout SurfaceOutputStandard o) {
			if (_Blind) {
				//Since the objects in blind mode ONLY reflect light and don't have any color, there's no need
				//to get any color data from the texture
				o.Albedo = 0, 0, 0; 
				o.Alpha = 1;
				o.Metallic = 0.5; //Back when Blind was a material rather than a Shader, these values seemed to work.
				o.Smoothness = 0.0;
			}
			else {
				float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgba;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
		}

		ENDCG
	}
	FallBack "Diffuse"
}