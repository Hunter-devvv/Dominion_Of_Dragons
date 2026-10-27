Shader "Custom/BillboardEffect"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor;
                float4 _BaseMap_ST;
            CBUFFER_END

            //CUSTOM CODE CAN TRANSFORM THE POSITON SCALE AND ROTATION OF OBJECT.
            float4 Transformation(float4 positionOS)
            {
                float4x4 IDENTITY_MATRIX=float4x4
                (
                    2,0,0,0,
                    0,1,0,0,
                    0,0,1,0,
                    0,0,0,1
                );

                return mul(IDENTITY_MATRIX,positionOS);
             }
              //CUSTOM CODE CAN TRANSFORM THE POSITON SCALE AND ROTATION OF OBJECT.


              //CUSTOM CODE
            Varyings vert(Attributes IN)
            {
                Varyings OUT;


                //this line changes for transformation multiplier
                float4 vertexOS=Transformation(IN.positionOS);



                //this line changes for BILLBOARD EFFECT
           //ORIGANAL:     float4 vertexWS=mul(UNITY_MATRIX_M, vertexOS);
                float4 vertexWS=mul(UNITY_MATRIX_M,float4(0,0,0,1));


                //this line IS ADDED for BILLBOARD EFFECT
                float3 vertexIVS=mul(UNITY_MATRIX_I_V, vertexOS.xyz);
                //puts object tto oposite derection of camera           UNITY_MATRIX_I_V is inverse view(camera) space


                //this line changes for BILLBOARD EFFECT                
                //ORIGANAL:    float4 vertexHCS=mul(UNITY_MATRIX_VP,float4(vertexWS.xyz,1.0));
                float4 vertexHCS=mul(UNITY_MATRIX_VP,float4(vertexWS + vertexIVS,1.0));
                //combindes global translation with camera faceing roataion.

                OUT.positionHCS = vertexHCS;
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;
                return color;
            }
            ENDHLSL
        }
    }
}
