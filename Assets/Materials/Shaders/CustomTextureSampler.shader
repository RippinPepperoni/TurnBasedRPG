Shader "Custom/CustomTextureSampler"
{
    Properties
    {
        [HideInInspector] _MainTex("Texture", 2D) = "white" {}

		_Color("Color", Color) = (0, 0, 0, 1)

		_Texture ("Texture", 2D) = "white" {}
		_Weight ("Weight", Range(0, 1)) = 0
		_Alpha("Alpha", Range (0, 1)) = 1

		[Toggle(USE_TEXTURE)] _UseTexture("Use Texture", float) = 0
    }
    SubShader
    {
        Tags 
		{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
			"PreviewType" = "Plane"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma shader_feature USE_TEXTURE	

            #include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _Texture;

			float4 _MainTex_ST;
			half4 _MainTex_TexelSize;

			float4 _Color;

			float _Weight;
			float _Alpha;

            struct appdata
            {
                float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
            };

            v2f vert (appdata IN)
            {
                v2f OUT;

                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = TRANSFORM_TEX(IN.texcoord, _MainTex);

				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0) 
				{
					OUT.texcoord.y = 1 - OUT.texcoord.y;
				}
				#endif

                return OUT;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
				fixed4 col = tex2D(_MainTex, IN.texcoord) * _Color;
				fixed4 sample = tex2D(_Texture, IN.texcoord);

				col.a = _Alpha;

				#ifdef USE_TEXTURE
				
				#else
					_Weight = 1;	
				#endif

				float visible = -sample + _Weight - 0.001f;
				clip(visible);
                
				if (sample.b < _Weight) 
				{
					return col;
				}

				return tex2D(_MainTex, IN.texcoord);
            }

            ENDCG
        }
    }
}
