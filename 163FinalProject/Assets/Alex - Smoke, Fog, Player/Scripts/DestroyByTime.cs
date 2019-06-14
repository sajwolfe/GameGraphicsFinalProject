using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}
