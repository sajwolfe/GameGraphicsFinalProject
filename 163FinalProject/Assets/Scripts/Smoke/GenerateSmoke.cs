using UnityEngine;

//alex
//allows you to spawn new smoke from inspector
//TODO: spawn smoke at specified time interval with random offset
[RequireComponent(typeof(ApplySmokeShader))]
public class GenerateSmoke : MonoBehaviour
{
    //[SerializeField] [Range(0, 512)] private float offsetX;
    //[SerializeField] [Range(0, 512)] private float offsetY;

    private ApplySmokeShader applySmokeShader;

    [SerializeField] [Range(0, 3)] private float generateTime;
    private float timer = 0;


    private void Start()
    {
        applySmokeShader = GetComponent<ApplySmokeShader>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= generateTime)
        {
            Vector3 offset = new Vector3(Random.Range(0, 900), Random.Range(256, 1000));
            applySmokeShader.AddSmoke(offset);

            timer = 0;
        }
        
    }

    //[ContextMenu("Spawn Smoke")]
    //public void SpawnSmoke()
    //{
    //    Vector3 offset = new Vector3(offsetX, offsetY);
    //    applySmokeShader.AddSmoke(offset);
    //}
}
