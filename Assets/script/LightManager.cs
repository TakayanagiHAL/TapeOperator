using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Material mat;

    public float exposurenum = 2.0f;


    public float exposurechangevalue = 0.01f;

    private float exposuretargetvalue;
    
    // Start is called before the first frame update
    void Start()
    {
        exposuretargetvalue = exposurenum;
        Debug.Log("just");

    }

    // Update is called once per frame
    void Update()
    {

        if (exposurenum >= exposuretargetvalue - 0.01f && exposurenum <= exposuretargetvalue + 0.01f)
        {
            exposurenum = exposuretargetvalue;
            Debug.Log("just");
        }
        else if (exposurenum > exposuretargetvalue)
        {
            exposurenum -= exposurechangevalue;
            Debug.Log("big");
        }
        else if (exposurenum < exposuretargetvalue)
        {
            exposurenum += exposurechangevalue;
            Debug.Log("small");
        }

        mat.SetFloat("_Exposure", exposurenum);
    }

    public void SetExPosure(float target)
    {
        exposuretargetvalue = target;
    }
}
