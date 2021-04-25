Shader "Custom/CustomDefaultSprite"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[PerRendererData] _Color("Color", Color) = (1, 1, 1, 1)

		[PerRendererData] _Alpha("Alpha", Range (0, 1)) = 1

		_NoiseTex ("Noise Texture2D", 2D) = "white" {}

		_Fade("Fade", Range (0, 1)) = 1

		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader
    {
        Tags 
		{ 
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True" 
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
			#pragma multi_compile _ PIXELSNAP_ON

            #include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _NoiseTex;

			fixed4 _Color;

			float _Alpha;
			float _Fade;

			struct appdata
            {
                float4 vertex : POSITION;
                float4 color  : COLOR;
				float2 texcoord : TEXCOORD0;
				float3 objectPos : TEXCOORD1;
            };

			struct v2f
            {
				float4 vertex : SV_POSITION;
				fixed4 color  : COLOR;
				float2 texcoord : TEXCOORD0;
				float3 objectPos : TEXCOORD1;
            };

			v2f vert (appdata IN)
            {
                v2f OUT;

				OUT.objectPos = mul(unity_WorldToObject, IN.vertex);
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;

				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
				#endif

                return OUT;
            }

			fixed4 frag (v2f IN) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, IN.texcoord) * IN.color;
				fixed4 mask = tex2D(_NoiseTex, IN.texcoord - (_Time / 8));

				mask += (IN.objectPos.y * - 1);
			
				half4 blend = step(_Fade * 2 - ((_Fade * -1) + 1), mask);
				color.a *= blend;

                return color;
            }

            ENDCG
        }
    }
}
