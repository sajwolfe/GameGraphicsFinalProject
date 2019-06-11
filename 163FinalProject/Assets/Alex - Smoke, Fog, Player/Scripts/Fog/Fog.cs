using UnityEngine;

//alex c
//https://twitter.com/roystanhonks/status/990755998280265728?lang=en
//this script goes on the actual fog object
public class Fog : MonoBehaviour
{
    [SerializeField, Tooltip("Resolution of the displacement map")]
    int resolution = 11;

    [SerializeField, Tooltip("Size of the fog space in Unity units, width = height")]
    float size = 50;

    [SerializeField, Tooltip("Maximum depth the fog can depress")]
    float depth = 10;

    [SerializeField, Tooltip("Multiplies the radius objects affect the fog")]
    float affectorMultiplier = 2;

    [SerializeField]
    float lerpSpeed = 1;

    Renderer fogRenderer;


    private Color[] heightMap;
    private Texture2D texture;

    private float halfSize;

    private void Awake()
    {
        halfSize = size * 0.5f;

        heightMap = new Color[resolution * resolution];

        //clear heightmap
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                SetHeightmapValue(x, y, 0);
            }
        }

        //
        fogRenderer = GetComponent<Renderer>();
        texture = new Texture2D(resolution, resolution, TextureFormat.RHalf, false);
        texture.wrapMode = TextureWrapMode.Clamp;

        fogRenderer.material.SetTexture("_DisplacementTex", texture);
        fogRenderer.material.SetFloat("_Size", size);
        fogRenderer.material.SetFloat("_MaxDisplacement", depth);
    }

    private void Update()
    {
        LerpHeightmap();
    }

    private void LateUpdate()
    {
        texture.SetPixels(heightMap);
        texture.Apply();
    }

    //Called from AffectFog script, the objects that actually affect the fog
    public void Impact(Vector3 position, float radius)
    {
        float affectorSize = radius * affectorMultiplier;

        Vector3 local = transform.InverseTransformPoint(position);

        float penetrationDepth = Mathf.Abs(local.y - radius);

        Vector2 resPoint = LocalToResolutionSpace(local);
        float resSize = LocalToResolutionScalar(affectorSize);
        float scaledDepth = penetrationDepth / depth;

        AffectInRadius(resPoint, resSize, scaledDepth);
    }

    //slowly returns heightmap to default
    private void LerpHeightmap()
    {
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                float current = GetHeightmapValue(x, y);
                float target = Mathf.Lerp(current, 0, lerpSpeed * Time.deltaTime);
                SetHeightmapValue(x, y, target);
            }
        }
    }

    //returns 0-1 
    private float GetHeightmapValue(int x, int y)
    {
        return heightMap[ToFlatIndex(x, y)].r;
    }

    //set heightmap val; 0-1
    private void SetHeightmapValue(int x, int y, float value)
    {
        heightMap[ToFlatIndex(x, y)] = new Color(value, 0, 0);
    }

    //clamps max value of heightmap
    private void SetHeightmapValueMax(int x, int y, float value)
    {
        heightMap[ToFlatIndex(x, y)] = new Color(Mathf.Max(GetHeightmapValue(x, y), value), 0, 0);
    }

    //actually affecting the heightmap
    private void AffectInRadius(Vector2 resPosition, float resRadius, float scaledDepth)
    {
        float adjustedRadius = resRadius + 0.5f;

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                Vector2 p = new Vector2(x, y) + Vector2.one * 0.5f;

                float distance = Vector2.Distance(resPosition, p);

                if (distance <= adjustedRadius)
                {
                    float t = 1 - (distance / adjustedRadius);

                    SetHeightmapValueMax(x, y, t * scaledDepth);
                }
            }
        }
    }

    
    private int ToFlatIndex(int x, int y)
    {
        return y * resolution + x;
    }

    private Vector2 LocalToResolutionSpace(Vector3 local)
    {
        Vector2 uv = new Vector2(local.x / size, local.z / size) + Vector2.one * 0.5f;
        return uv * resolution;
    }
  
    private float LocalToResolutionScalar(float localScalar)
    {
        return (localScalar / size) * resolution;
    }
}