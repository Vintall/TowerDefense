// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/PlacingCircleShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1) // add _Color property
    }

        SubShader
        {
            Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull front
            LOD 100

            Pass
            {
                CGPROGRAM

                #pragma vertex vert alpha
                #pragma fragment frag alpha

                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex   : POSITION;
                };

                struct v2f
                {
                    float4 vertex  : SV_POSITION;
                };

                float4 _Color;

                v2f vert(appdata_t v)
                {
                    v2f o;

                    o.vertex = UnityObjectToClipPos(v.vertex);

                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = _Color; // multiply by _Color
                    return col;
                }

                ENDCG
            }
        }
}