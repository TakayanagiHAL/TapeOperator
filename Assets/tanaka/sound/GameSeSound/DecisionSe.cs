using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionSe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Select"))
        {
            Sound.PlaySeByName("SE_Decision");
        }

        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Sound.StopSe();
        //}
        //if (Input.GetKeyDown(KeyCode.F4))
        //{
        //    Sound.PlaySeByName("SE_Decision");
        //}
    }
}
