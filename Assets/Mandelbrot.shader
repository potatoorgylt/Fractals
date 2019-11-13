Shader "Fractal/Mandelbrot"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Area("Area", vector) = (0, 0, 4, 4)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float random (float2 uv)
            {
                return frac(sin(dot(uv,float2(12.9898,78.233)))*43758.5453123);
            }

            sampler2D _MainTex;
            float4 _Area; 

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float2 c = _Area.xy+(i.uv-.5)*_Area.zw;

                float2 z;
                float dist = 0.;

                float iter = 0.;
                float max_iter = 1000.;

                for(float i = 0.0; i < max_iter; i++){
                    dist = dot(z, z);
                    z = float2(z.x*z.x-z.y*z.y, 2*z.x*z.y) + c;
				    if (length(z) > 2.) break;
					    iter++;
                }

				float intensity = iter * 0.05;//(max_iter);
                
                float2 center = 0.5;

                iter += _Time * 10.0;

                dist = sqrt(dist);
                float gradient = float(log(dist)*sqrt(dist));
                col.rgb = float3(0.5 * sin(iter) + 0.5 * gradient * intensity, 0.5 * cos(iter) + 0.5 * gradient * intensity, 0.5 * sin(iter*3.0) + 0.5 * gradient * intensity);

                //col.rgb = float3(0.5 * sin(iter) + 0.5, 0.5 * cos(iter) + 0.5, 0.5 * sin(iter*3.0) + 0.5);

                return col;
            }
            ENDCG
        }
    }
}
