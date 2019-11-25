Shader "Custom/waterShader"
{
    Properties
    {
        _Color ("Color", Color) = (11,11,184,100)
        _WaveNormalMap("NormalMap", 2D) = "bump" {}
        _DistortionMap("DistortionMap", 2D) = "black" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
 
        GrabPass{}        
 
        CGPROGRAM
       
        #pragma surface surf _CatDarkLight  vertex:vert noshadow
 
 
        void vert(inout appdata_full v)
        {
            v.vertex.y += sin((abs(v.texcoord.x * 1.5f - 1.0f)*10.0f) + _Time.y*0.8f) * 0.12f +
                sin((abs(v.texcoord.y * 1.5f - 1.0f)*10.0f) + _Time.y*0.8f) * 0.02f;
        }
 
        sampler2D _WaveNormalMap;
        sampler2D _DistortionMap;
        sampler2D _GrabTexture;        
        
 
        struct Input
        {
            float2 uv_WaveNormalMap;
            float2 uv_DistortionMap;
            float3 viewDir;
 
            float4 screenPos;    
 
            float3 worldRefl;
            INTERNAL_DATA
        };
 
        fixed4 _Color;
 
        void surf (Input IN, inout SurfaceOutput o)
        {  
            //o.Albedo = 1.0f;
 
            float fNormalWaveSpeed = 0.01f;
            float3 fNormal_L = UnpackNormal(tex2D(_WaveNormalMap, IN.uv_WaveNormalMap - float2(0, _Time.y*fNormalWaveSpeed)));
            float3 fNormal_R = UnpackNormal(tex2D(_WaveNormalMap, IN.uv_WaveNormalMap + float2(0, _Time.y*fNormalWaveSpeed)));
            float3 fNormal_T = UnpackNormal(tex2D(_WaveNormalMap, IN.uv_WaveNormalMap - float2(_Time.y*fNormalWaveSpeed, 0)));
            float3 fNormal_B = UnpackNormal(tex2D(_WaveNormalMap, IN.uv_WaveNormalMap + float2(_Time.y*fNormalWaveSpeed, 0)));
            
            o.Normal = (fNormal_L + fNormal_R + fNormal_T + fNormal_B) / 4.0f;
 
 
            float3 fWorldReflectionVector = WorldReflectionVector(IN, o.Normal).xyz;
            float3 fReflection = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, fWorldReflectionVector).rgb * unity_SpecCube0_HDR.r;
 
 
            float4 fDistortion = tex2D(_DistortionMap, IN.uv_DistortionMap + _Time.y*0.05f);    
 
            float3 scrPos = IN.screenPos.xyz / (IN.screenPos.w + 0.00001f);    
            float4 fGrab = tex2D(_GrabTexture, scrPos.xy + (fDistortion.r * 0.2f));        
 
            float fNDotV = dot(o.Normal, IN.viewDir);
            float fRim = saturate(pow(1 - fNDotV + 0.1f, 1));
 
            o.Emission = lerp(fGrab.rgb, fReflection, fRim);
        }
 
        float4 Lighting_CatDarkLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 fSpec = float4(0.0f, 0.0f, 0.0f, 0.0f);
            float3 fHalfVector = normalize(lightDir + viewDir);
            float fSpecHDotN = saturate(dot(s.Normal, fHalfVector));
            fSpecHDotN = pow(fSpecHDotN, 100.0f);
 
            float4 fFinalColor = 0.0f;
            fFinalColor = fSpecHDotN;
 
            return fFinalColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
 