using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] Material mat;

    public float exposurenum = 2.0f;

    public float sunsizenum = 2.0f;

    public float exposurechangevalue = 0.00001f;

    public float sunsizechangenum = 0.001f;

    private float exposuretargetvalue;

    private float sunsizetargetvalue;
    
    // Start is called before the first frame update
    void Start()
    {
        exposuretargetvalue = exposurenum;
        sunsizetargetvalue = sunsizenum;
    }

    // Update is called once per frame
    void Update()
    {

        if (exposurenum <= exposuretargetvalue + 0.01f && exposurenum >= exposuretargetvalue - 0.01f)
        {
            exposurenum = exposuretargetvalue;
        }
        else if (exposuretargetvalue < exposurenum)
        {
            exposurenum -= exposurechangevalue;
        }
        else if (exposuretargetvalue > exposurenum)
        {
            exposurenum += exposurechangevalue;
        }

        if (sunsizenum <= sunsizetargetvalue + 0.01f && sunsizenum >= sunsizetargetvalue - 0.01f)
        {
            sunsizenum = sunsizetargetvalue;
        }
        else if (sunsizetargetvalue < sunsizenum)
        {
            sunsizenum -= sunsizechangenum;
        }
        else if (sunsizetargetvalue > sunsizenum)
        {
            sunsizenum += sunsizechangenum;
        }

        mat.SetFloat("_Exposure", exposurenum);
        mat.SetFloat("_SunSize", sunsizenum);
    }

    public void SetExPosure(float target)
    {
        exposuretargetvalue = target;
        Debug.Log("LIGHT_SET");
    }

    public void SetSunSize(float target)
    {
        sunsizetargetvalue = target;
    }
}
