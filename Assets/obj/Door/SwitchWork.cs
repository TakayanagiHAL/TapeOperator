using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWork : MonoBehaviour
{
    public bool is_enter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        is_enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        is_enter = false;
    }
}
