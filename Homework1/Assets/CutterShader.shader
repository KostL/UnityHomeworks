Shader "Custom/CutterShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NormMap ("BumpMap", 2D) = "bump" {}
        _Color ("Color", Color) = (1,1,1,1)

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Off
        CGPROGRAM

        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormMap;
            float3 worldPos;
        };        

        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _NormMap;

        void surf (Input IN, inout SurfaceOutput o)
        {
            clip (frac((IN.worldPos.x + IN.worldPos.y + IN.worldPos.z * 0.05) * 2) - 0.5);
            
            
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
            o.Normal = UnpackNormal(tex2D(_NormMap, IN.uv_NormMap));

            
        }
        ENDCG
    }
    FallBack "Diffuse"
}
