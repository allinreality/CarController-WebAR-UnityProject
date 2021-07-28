Shader "MatteShadowCustModel" {
    Properties{
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
    }

        SubShader{
            Tags {"IgnoreProjector" = "True" "RenderType" = "TransparentCutout"}
            LOD 200

        CGPROGRAM
        #pragma surface surf SimpleLambert alphatest:_Cutoff

        sampler2D _MainTex;
        float4 _Color;

        struct Input {
            float2 uv_MainTex;
        };

         half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten) {
                  half NdotL = dot(s.Normal, lightDir);
                  half4 c;
                  c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2); //half3(atten, atten, atten);//
                  c.a = s.Alpha;
                  return c;
              }

        void surf(Input IN, inout SurfaceOutput o) {
            half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = 0.25;

        }
        ENDCG
        }

            Fallback "Transparent/Cutout/VertexLit"
}