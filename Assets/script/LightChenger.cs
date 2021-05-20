using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChenger : MonoBehaviour
{
    enum COUNTRY
    {
        AFRICA,
        ARCTIC_ANTARCTIC,
        AUSTRALIA,
        EGYPT,
        NORWAY,
        RUSSIA
    }

    [SerializeField] COUNTRY this_country;
    [SerializeField] test light;

    private bool this_sun;
    // Start is called before the first frame update
    void Start()
    {
        this_sun = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLighting(bool is_sun)
    {
        if(this_sun == is_sun)
        {
            return;
        }

        if (is_sun)
        {
            switch (this_country)
            {
                case COUNTRY.AFRICA:
                    light.SetExPosure(2.0f);
                    break;
                case COUNTRY.ARCTIC_ANTARCTIC:
                    light.SetExPosure(0.42f);
                    break;
                case COUNTRY.AUSTRALIA:
                    light.SetExPosure(1.61f);
                    break;
                case COUNTRY.EGYPT:
                    light.SetExPosure(2.0f);
                    break;
                case COUNTRY.NORWAY:
                    light.SetExPosure(2.0f);
                    break;
                case COUNTRY.RUSSIA:
                    light.SetExPosure(2.0f);
                    break;
            }
        }
        else
        {
            switch (this_country)
            {
                case COUNTRY.AFRICA:
                    light.SetExPosure(0.87f);
                    break;
                case COUNTRY.ARCTIC_ANTARCTIC:
                    light.SetExPosure(0.42f);
                    break;
                case COUNTRY.AUSTRALIA:
                    light.SetExPosure(0.61f);
                    break;
                case COUNTRY.EGYPT:
                    light.SetExPosure(1.0f);
                    break;
                case COUNTRY.NORWAY:
                    light.SetExPosure(1.0f);
                    break;
                case COUNTRY.RUSSIA:
                    light.SetExPosure(1.0f);
                    break;
            }
        }

        this_sun = is_sun;
    }
}
