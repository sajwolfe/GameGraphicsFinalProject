using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alex 
//tutorial: https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/
//
public class ApplySmokeShader : MonoBehaviour
{
    //material
    [SerializeField] private Material mat;

    //textures
    [SerializeField] private Texture initialTex;
    [SerializeField] private RenderTexture tex;
    private RenderTexture buffer;

    //timer
    private float lastUpdateTime = 0;
    [SerializeField] private float updateInterval;

    private void Start()
    {
        Graphics.Blit(initialTex, tex);
        buffer = new RenderTexture(tex.width, tex.height, tex.depth, tex.format);
    }

    private void Update()
    {
        //redo this with time.deltatime?
        if(Time.time > lastUpdateTime + updateInterval)
        {
            UpdateTexture();
            lastUpdateTime = Time.time;
        }
    }

    public void UpdateTexture()
    {
        Debug.Log("Update");
        Graphics.Blit(tex, buffer, mat);
        Graphics.Blit(buffer, tex);
    }
}
