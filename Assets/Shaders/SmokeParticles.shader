Shader "Custom/SmokeParticles"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		[HDR]_Emission("Emission", Color) = (1,1,1,1)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
			float4 vertexColor : COLOR;
        };

        half _Glossiness;
        half _Metallic;
		fixed4 _Emission;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			o.Albedo = _Color;

			o.Alpha = _Color.a;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Emission = _Emission;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
