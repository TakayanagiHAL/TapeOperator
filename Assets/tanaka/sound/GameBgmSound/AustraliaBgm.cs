using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AustraliaBgm : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        Sound.PlayBgmByName("BGM_Australia");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Sound.StopBgm();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Sound.PlayBgmByName("BGM_Australia");
        }
    }
}
