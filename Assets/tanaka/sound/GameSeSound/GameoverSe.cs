using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverSe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_Gameover");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Sound.StopSe("SE_Gameover");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Sound.PlaySeByName("SE_Gameover");
        }
    }
}
