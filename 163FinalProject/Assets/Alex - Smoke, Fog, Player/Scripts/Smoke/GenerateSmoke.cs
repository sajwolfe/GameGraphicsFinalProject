using UnityEngine;

//alex c
//allows you to spawn new smoke from inspector
[RequireComponent(typeof(ApplySmokeShader))]
public class GenerateSmoke : MonoBehaviour
{

    private ApplySmokeShader applySmokeShader;

    [SerializeField] [Range(0, 3)] private float generateTime;
    private float timer = 0;


    private void Start()
    {
        applySmokeShader = GetComponent<ApplySmokeShader>();
    }
    
    private void OnGUI()
    {
        timer += Time.deltaTime;
        if (timer >= generateTime)
        {
            Vector3 offset = new Vector3(Random.Range(0, 1000), Random.Range(256, 1000));
            applySmokeShader.AddSmoke(offset);
            timer = 0;
        }
    }



}
