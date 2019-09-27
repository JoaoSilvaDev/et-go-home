Shader "Custom/Transparent"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		[HDR]_Emission("Emission", Color) = (1, 1, 1, 1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader
		{
			Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 200
			ZWrite Off

			CGPROGRAM

			#pragma surface surf Standard fullforwardshadows alpha:fade
			#pragma target 3.0	

			sampler2D _MainTexture;
			half _Glossiness;
			half _Metallic;
			float4 _Emission;
			float4 vertexColor;

			struct Input
			{
				float2 uv_MainTex;
				fixed4 color : COLOR;
			};

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				o.Albedo = IN.color.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Emission = _Emission;

				o.Alpha = IN.color.a;
			}
			ENDCG
		}
		FallBack "Diffuse"
}
