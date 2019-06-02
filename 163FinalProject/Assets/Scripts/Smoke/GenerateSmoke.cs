using UnityEngine;

//alex
//allows you to spawn new smoke from inspector
//TODO: spawn smoke at specified time interval with random offset
[RequireComponent(typeof(ApplySmokeShader))]
public class GenerateSmoke : MonoBehaviour
{
    [SerializeField] [Range(0, 512)] private float offsetX;
    [SerializeField] [Range(0, 512)] private float offsetY;

    private ApplySmokeShader applySmokeShader;

    public void Start()
    {
        applySmokeShader = GetComponent<ApplySmokeShader>();
    }

    [ContextMenu("Spawn Smoke")]
    public void SpawnSmoke()
    {
        Vector3 offset = new Vector3(offsetX, offsetY);
        applySmokeShader.AddSmoke(offset);
    }
}
