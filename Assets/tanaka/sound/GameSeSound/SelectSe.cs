using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSe : MonoBehaviour
{
    private SoundManager Sound;

    bool isGetKey;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_Select");
    }

    // Update is called once per frame
    void Update()
    {

        float Hori = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.D) || Hori > 0 || Input.GetKeyDown(KeyCode.A) || Hori < 0 ||
            Input.GetKeyDown(KeyCode.W) || Vert > 0 || Input.GetKeyDown(KeyCode.S) || Vert < 0)
        {
            Sound.PlaySeByName("SE_Select");

        }

        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Sound.StopSe();
        //}
        //if (Input.GetKeyDown(KeyCode.F9))
        //{
        //    Sound.PlaySeByName("SE_Select");
        //}
    }
}
