using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_Open");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Select"))
        {
            Sound.PlaySeByName("SE_Open");
        }

        //ジャンプボタンで本を閉じる
        if (Input.GetButtonDown("Jump"))
        {
            Sound.PlaySeByName("SE_Open");
        }

    }
}
