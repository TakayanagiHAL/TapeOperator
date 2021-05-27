using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] Pages;   //各ページのCGameObjectを入れる配列
    public static int PageNum = 0;         //今のページ数を表す変数
    private Animator anim;                 //Animator取得用変数

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        PageNum = 0;

        //全部のCanvasをfalseにする
        for(int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }

        //アルバムのAnimatorコンポーネントを設定
        anim = this.GetComponent<Animator>();

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
            Pages[PageNum].SetActive(false);       //今のページのGameObjectをfalseにする
            PageNum--;                              //ページ数を１つ減らす  
            anim.SetBool("BeforePageFlag", true);  //前のページのアニメーションをtrueにする
        }
    }


    //次のページUIを呼ぶ関数
    public void NextPageCall()
    {
        if (PageNum < Pages.Length - 1) 
        {
            Pages[PageNum].SetActive(false);   //今のページのGameObjectをfalseにする
            PageNum++;                          //ページ数を１つ増やす  
            anim.SetBool("NextPageFlag", true);    //次のページのアニメーションをtrueにする
        }
    }

    public void CanvasDisp()
    {
        Pages[PageNum].SetActive(true);    //指定ページのGameObjectをtrueにする
    }

    //本を閉じる
    public void CloseBook()
    {
        Pages[PageNum].SetActive(false);   //今のページのGameObjectをfalseにする
        anim.SetBool("CloseFlag", true);
        anim.SetBool("OpenFlag", false);
    }
}
