Shader "Unlit/NewUnlitShader"
{
	SubShader
    {
        Tags {"Queue"="Background"}

		ZWrite On
		ZTest LEqual
		ColorMask 0

        Pass {}
    }
}
