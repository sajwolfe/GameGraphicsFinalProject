using UnityEngine;

//alex
//allows you to spawn new smoke from inspector
//TODO: spawn smoke at specified time interval with random offset
[RequireComponent(typeof(ApplySmokeShader))]
public class GenerateSmoke : MonoBehaviour
{
    [SerializeField] [Range(0, 512)] private Vector2 offset;

    private ApplySmokeShader applySmokeShader;

    public void Start()
    {
        applySmokeShader = GetComponent<ApplySmokeShader>();
    }

    [ContextMenu("Spawn Smoke")]
    public void SpawnSmoke()
    {
        applySmokeShader.AddSmoke(offset);
    }
}
