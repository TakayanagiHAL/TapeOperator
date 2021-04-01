using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
     FPS表示プログラム
     画面に表示させる際は場所と位置を調整したTextをアタッチさせる
     F3キーで画面表示切替
*/
public class FPSCheck : MonoBehaviour
{
    public Text text;

    public bool is_text;

    int frameCount;

    float prevTime;

    float fps;

    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;

        prevTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (Input.GetKeyUp(KeyCode.F3))
        {
            if (is_text)
            {
                is_text = false;
               // Debug.Log("text_off");
            }else {
                is_text = true;
               // Debug.Log("text_on");
            }
        }

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            //Debug.Log(fps.ToString());
            if (is_text)
            {
                text.text = fps.ToString();
            }
            else
            {
                text.text = "";
            }

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
