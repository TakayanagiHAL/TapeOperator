using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleBlockWork : MonoBehaviour
{
    private int flame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flame++;
        if (flame >= 60 * 5)
        {
            Destroy(this.gameObject);
        }
    }
}
