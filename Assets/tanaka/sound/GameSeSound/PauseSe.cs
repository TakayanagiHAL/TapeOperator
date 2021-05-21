using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_Pause");
    }

    // Update is called once per frame
    void Update()
    {

        bool lt = Input.GetButtonDown("Menu");

        if(lt)
        {
            Sound.PlaySeByName("SE_Pause");
        }
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Sound.StopSe();
        //}
        //if (Input.GetKeyDown(KeyCode.F7))
        //{
        //    Sound.PlaySeByName("SE_Pause");
        //}
    }
}
