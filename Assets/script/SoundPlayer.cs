using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private static SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.Awake();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StopBGM()
    {
        Sound.StopBgm();
    }

    public static SoundManager GetSoundManagaer()
    {
        return Sound;
    }

    public void PlayDecision()
    {
        Sound.PlaySeByName("SE_Decision");
    }
    public void PlaySelect()
    {
        Sound.PlaySeByName("SE_Select");
    }
}
