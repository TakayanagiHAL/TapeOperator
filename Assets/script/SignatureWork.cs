using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignatureWork : MonoBehaviour
{
    [SerializeField] Fade fade;
    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            fade.StartFade();
            start = true;
        }
        if (Fade.FadeFinish)
        {
            if (fade.FadeOut)
            {
                Fade.FadeFinish = false;
                ScheneChanger.ChangeScene((int)ScheneChanger.SCENE_NAME.STAGE_SELECT);
            }
            else
            {
                fade.FadeOut = true;
                Fade.FadeFinish = false;
                fade.StartFade();
            }
        }
    }
}
