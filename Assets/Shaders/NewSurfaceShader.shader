Shader "Custom/Transparent"
{
	Properties
	{
		[HDR]_Emission("Emission", Color) = (1, 1, 1, 1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Dissolve ("Dissolve", 2D) = "white" {}
	}
		SubShader
		{
			Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 200

			ZWrite Off

			CGPROGRAM

			#pragma surface surf Standard fullforwardshadows alpha:fade
			#pragma target 3.0			

			half _Glossiness;
			half _Metallic;
			float4 _Emission;
			float4 vertexColor;
			sampler2D _Dissolve;

			struct Input {
				fixed4 color : COLOR;
				float2 uv_Dissolve;
			};

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				o.Albedo = IN.color.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Emission = _Emission;

				half diss = tex2D(_Dissolve, IN.uv_Dissolve).rgb - _Metallic;
				clip(diss);

				//o.Alpha = IN.color.a;
			}
			ENDCG
		}
		FallBack "Diffuse"
}
