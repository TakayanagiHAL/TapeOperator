using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject FadePanel;
    [SerializeField] bool FadeOut = true;
    public static bool FadeStart = false;
    private float alfa;
    private float speed = 0.01f;
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
            FadeStart = true;
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

        //フェード開始したら
        if (FadeStart == true)
        {
            if (FadeOut == true)
            {
                //フェードアウト
                FadePanel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
            else
            {
                //フェードイン
                FadePanel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa -= speed;
            }
        }

    }
}
