//alex c
//tutorial https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/
//shader that slowly disperses smoke from alpha / white texture
Shader "Alex/SmokeShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		[HideInInspector] _Pixels("Pixels", float) = 512
		[HideInInspector] _Dissipation("Dissipation", float) = 1
		[HideInInspector] _Mininmum("Minimum", float) = 0.03
		_Speed("Dispersion Speed", Range(0, 0.01)) = 0.001
	}

	SubShader
	{
		ZTest Always Cull Off Zwrite Off
		Fog{ Mode off }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct appdata
			{
				float4 pos : POSITION;
				float4 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float4 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			float _Pixels;
			float _Dissipation;
			float _Minimum;
			float _Speed;

			v2f vert(appdata v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.pos);
				o.uv = v.uv;

				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
				// center
				fixed2 uv = round(i.uv * _Pixels) / _Pixels;

				// nearby cells
				half s = 1 / _Pixels;
				float cl = tex2D(_MainTex, uv + fixed2(-s, 0)).a;  // center left
				float tc = tex2D(_MainTex, uv + fixed2(-0, -s)).a; // center top
				float cc = tex2D(_MainTex, uv + fixed2(0, 0)).a;   // center center
				float bc = tex2D(_MainTex, uv + fixed2(0, +s)).a;  // center bottom
				float cr = tex2D(_MainTex, uv + fixed2(+s, 0)).a;  // center right

				// diffusion
				float factor =
					_Dissipation *
					(
						0.25 * (cl + tc + bc + cr)
						- (1 + _Speed) * cc
					);
				
				// minimum 
				if (factor >= -_Minimum && factor < 0.0)
					factor = -_Minimum;

				cc += factor;

				// clamp to 0 so they always disappear eventually
				if (cc <= 0.05)
				{
					cc = 0;
				}

				return float4(1, 1, 1, cc);
			}

			ENDCG
		}
	}
}
