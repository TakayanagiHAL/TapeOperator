using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussiaBgm : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        Sound.PlayBgmByName("BGM_Russia");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Sound.StopBgm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Sound.PlayBgmByName("BGM_Russia");
        }
    }
}
