using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] Canvas;   //各ページのCanvasを入れる配列
    public static int PageNum = 0;         //今のページ数を表す変数
    private Animator anim;                 //Animator取得用変数

    // Start is called before the first frame update
    void Start()
    {
        //全部のCanvasをfalseにする
        for(int i = 0; i < Canvas.Length; i++)
        {
            Canvas[i].SetActive(false);
        }

        //アルバムのAnimatorコンポーネントを設定
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //決定ボタンで本を開く
        if (Input.GetButtonDown("Select"))
        {
            anim.SetBool("OpenFlag", true);
        }

        //ジャンプボタンで本を閉じる
        if (Input.GetButtonDown("Jump"))
        {
            Canvas[PageNum].SetActive(false);   //今のページのCanvasをfalseにする
            anim.SetBool("CloseFlag", true);
        }
    }


    //前のページUIを呼ぶ関数
    public void BeforePageCall()
    {
        //ページ数が0より大きい場合
        if (PageNum > 0)
        {
            Canvas[PageNum].SetActive(false);       //今のページのCanvasをfalseにする
            PageNum--;                              //ページ数を１つ減らす  
            anim.SetBool("BeforePageFlag", true);  //前のページのアニメーションをtrueにする
        }
    }


    //次のページUIを呼ぶ関数
    public void NextPageCall()
    {
        if (PageNum < Canvas.Length - 1) 
        {
            Canvas[PageNum].SetActive(false);   //今のページのCanvasをfalseにする
            PageNum++;                          //ページ数を１つ増やす  
            anim.SetBool("NextPageFlag", true);    //次のページのアニメーションをtrueにする
        }
    }

    public void CanvasDisp()
    {
        Canvas[PageNum].SetActive(true);    //指定ページのCanvasをtrueにする
    }
}
