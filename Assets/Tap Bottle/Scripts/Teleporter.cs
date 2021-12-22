using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform target2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BottleCap"))
        {
            other.gameObject.transform.position = target2.position;
        }
    }
}
