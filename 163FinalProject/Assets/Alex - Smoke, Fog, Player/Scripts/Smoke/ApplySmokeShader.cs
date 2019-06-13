using UnityEngine;

//alex c
//tutorial: https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/
//
public class ApplySmokeShader : MonoBehaviour
{

    //main camera
    [SerializeField] private GameObject mainCamera;

    //material
    [SerializeField] private Material mat;

    //textures
    [SerializeField] private int texSize = 512;
    [SerializeField] private Texture initialTex;
    [SerializeField] private RenderTexture tex;
    private RenderTexture buffer;

    //timer
    private float timer = 0;
    [SerializeField] private float updateInterval;

    private void Start()
    {
        Graphics.Blit(initialTex, tex);
        buffer = new RenderTexture(tex.width, tex.height, tex.depth, tex.format);
    }

    private void Update()
    {
        //timer for updating texture for smoke dispersion
        timer += Time.deltaTime;
        if(timer > updateInterval)
        {
            UpdateTexture();
            timer = 0;
        }

        //rotate to face camera
        if (mainCamera != null) transform.LookAt(mainCamera.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private void UpdateTexture()
    {
        Graphics.Blit(tex, buffer, mat);
        Graphics.Blit(buffer, tex);
    }

    //called to add new smoke to the quad
    public void AddSmoke(Vector2 offset)
    {
        Graphics.SetRenderTarget(tex);
        Graphics.DrawTexture(new Rect(offset.x, offset.y, 300, 300), initialTex);
        Graphics.SetRenderTarget(null);
    }
}
