Shader "Unlit/OcclusionShader"
{
	SubShader
    {
        Tags { "Queue"="Geometry" }

		ZWrite On
		ZTest Equal
		ColorMask 0
    }
}
