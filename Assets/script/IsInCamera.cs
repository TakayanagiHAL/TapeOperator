using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInCamera : MonoBehaviour
{
    public bool is_visible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //is_visible = false;
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.tag == "MainCamera")
        {
            if (!is_visible)
            {
                is_visible = true;
            }
        }
        
    }
}
