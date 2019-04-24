Shader "Unlit/Practice_Shadder"
{
    Properties
    {
        _Color   ("New Color", Color) = (1, 1, 1, 1)
        _MainTex ("Main Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 position : SV_POSITION;
            };


            float4 _Color;

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata IN)
            {
                v2f OUT;
                OUT.position = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;


                return OUT;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
                
                return tex2D(_MainTex, IN.uv);

            }

            ENDCG
        }
    }
}
