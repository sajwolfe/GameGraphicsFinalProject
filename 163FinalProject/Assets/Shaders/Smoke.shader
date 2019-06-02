//alex
//tutorial https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/
//
Shader "Alex/SmokeShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Pixels("Pixels", float) = 5
		_Dissipation("Dissipation", float) = 5
		_Mininmum("Minimum", float) = 50
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

			v2f vert(appdata v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.pos);
				o.uv = v.uv;

				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
				// Cell centre
				fixed2 uv = round(i.uv * _Pixels) / _Pixels;

				// Neighbour cells
				half s = 1 / _Pixels;
				float cl = tex2D(_MainTex, uv + fixed2(-s, 0)).a; // Centre Left
				float tc = tex2D(_MainTex, uv + fixed2(-0, -s)).a; // Top Centre
				float cc = tex2D(_MainTex, uv + fixed2(0, 0)).a; // Centre Centre
				float bc = tex2D(_MainTex, uv + fixed2(0, +s)).a; // Bottom Centre
				float cr = tex2D(_MainTex, uv + fixed2(+s, 0)).a; // Centre Right

				// Diffusion step
				float factor =
					_Dissipation *
					(
						0.25 * (cl + tc + bc + cr)
						- cc
					);
				
				
				if (factor >= -_Minimum && factor < 0.0)
					factor = -_Minimum;

				cc += factor;

				return float4(1, 1, 1, cc);

				//float4 c = tex2D(_MainTex, i.uv);
				//return 1 - c;
			}

			ENDCG
		}
	}
}
