using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject FadePanel;
    public bool FadeOut = true;
    public static bool FadeStart = false;
    public static bool FadeFinish = false;
    private float alfa;
    [SerializeField] float speed = 0.001f;
    private float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        red = FadePanel.GetComponent<Image>().color.r;
        green = FadePanel.GetComponent<Image>().color.g;
        blue = FadePanel.GetComponent<Image>().color.b;
        FadePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           // StartFade();
        }

        //フェード開始したら
        if (FadeStart == true)
        {
            Debug.Log(speed);
            if (FadeOut == true)
            {
                //フェードアウト
                FadePanel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;

                if (alfa >= 1)
                {
                    FadeStart = false;
                    FadeFinish = true;
                }
            }
            else
            {
                //Debug.Log("in");
                //フェードイン
                FadePanel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa -= speed;

                if (alfa <= 0)
                {
                    FadeStart = false;
                    FadeFinish = true;
                }
            }
        }

    }

    public void StartFade()
    {
        FadeStart = true;
        FadeFinish = false;
        FadePanel.SetActive(true);

        if (FadeOut == true)
        {
            //フェードアウト
            alfa = 0.0f;
        }
        else
        {
            //フェードイン
            alfa = 1.0f;
        }
    }


}
