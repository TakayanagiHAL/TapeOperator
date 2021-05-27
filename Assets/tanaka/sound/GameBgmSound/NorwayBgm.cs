using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorwayBgm : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        Sound.PlayBgmByName("BGM_Norway");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Sound.StopBgm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Sound.PlayBgmByName("BGM_Norway");
        }
    }
}
