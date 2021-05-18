using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnObject : MonoBehaviour
{
    private int burn_count;
    // Start is called before the first frame update
    void Start()
    {
        burn_count = 5 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (burn_count <= 0)
        {
            this.enabled = false;
        }
    }

    public void Burn()
    {
        burn_count--;
    }
}
