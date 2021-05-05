Shader "Custom/CustomDefaultSprite"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[PerRendererData] _Color("Color", Color) = (1, 1, 1, 1)

		[PerRendererData] _Alpha("Alpha", Range (0, 1)) = 1

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
            };

			struct v2f
            {
				float4 vertex : SV_POSITION;
				fixed4 color  : COLOR;
				float2 texcoord : TEXCOORD0;
            };

			v2f vert (appdata IN)
            {
                v2f OUT;

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

                return color;
            }

            ENDCG
        }
    }
}
