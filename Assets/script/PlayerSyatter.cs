using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSyatter : MonoBehaviour
{
    private bool is_se = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_se)
        {
            SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Clearshutter");
            is_se = true;
        }
    }
}
