using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_Clear");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Sound.StopSe("SE_Clear");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Sound.PlaySeByName("SE_Clear");
        }
    }
}
