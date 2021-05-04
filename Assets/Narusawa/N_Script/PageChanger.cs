using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] Canvas;   //各ページのCanvasを入れる配列
    public static int PageNum = 0;          //今のページ数を表す変数

    // Start is called before the first frame update
    void Start()
    {
        //全部のCanvasをfalseにする
        for(int i = 0; i < Canvas.Length; i++)
        {
            Canvas[i].SetActive(false);
        }
        Canvas[PageNum].SetActive(true);    //今のページのCanvasをtrueにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //前のページUIを呼ぶ関数
    public void BeforePageCall()
    {
        //ページ数が0より大きい場合
        if (PageNum > 0)
        {
            Canvas[PageNum].SetActive(false);   //今のページのCanvasをfalseにする
            PageNum--;                          //ページ数を１つ減らす  
            Canvas[PageNum].SetActive(true);    //減らした後のページのCanvasをtrueにする
        }
    }


    //次のページUIを呼ぶ関数
    public void NextPageCall()
    {
        if (PageNum < Canvas.Length)
        {
            Canvas[PageNum].SetActive(false);   //今のページのCanvasをfalseにする
            PageNum++;                          //ページ数を１つ増やす  
            Canvas[PageNum].SetActive(true);    //増やした後のページのCanvasをtrueにする
        }
    }
}
