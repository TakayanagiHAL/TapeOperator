using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvyCollision : MonoBehaviour
{
    private bool Hit = false;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ivytop") || other.gameObject.CompareTag("button"))
        {
            Hit = true;
        }
        Debug.Log("Hit");
    }
    private void OnTriggerExit(Collider other)
    {
        Hit = false;
        Debug.Log("NoHit");
    }

    public bool GetHit()
    {
        return Hit;
    }
}
