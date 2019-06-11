using UnityEngine;

//alex c
//https://twitter.com/roystanhonks/status/990755998280265728?lang=en
//objects with this will affect fog height when colliding

public class AffectFog : MonoBehaviour
{
    [SerializeField]
    float radius = 0.5f;

    private void OnTriggerStay(Collider other)
    {
        Fog fog = other.GetComponentInParent<Fog>();

        if (fog != null)
        {
            fog.Impact(transform.position, radius);
        }
    }
}
