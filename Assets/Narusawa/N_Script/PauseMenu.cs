using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject GameCanvas;      //ゲームUIのパネル
    [SerializeField] GameObject PauseCanvas;     //ポーズUIのパネル
    public static bool PauseEnable = false;      //ポーズ状態かのフラグ


    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.SetActive(true);       //ゲームUIをtrueにする
        PauseCanvas.SetActive(false);     //ポーズUIをfalseにする
        PauseEnable = false;    //ゲーム状態にする
    }


    // Update is called once per frame
    void Update()
    {
        //メニューボタンが押された時
        if (Input.GetButtonDown("Menu"))
        {
            PauseEnable = !PauseEnable;     //ポーズ状態のフラグを切り替える

            if (PauseEnable == true)    //ポーズ中
            {
                GameCanvas.SetActive(false);    //ゲームUIをfalseにする
                PauseCanvas.SetActive(true);    //ポーズUIをtrueにする
                PauseManager.TimeStop();        //ゲームの時間を止める
                Debug.Log("ポーズ中");
            }
            else
            {
                ReturnGame();
            }

        }
    }

    //PauseからGameに戻る関数
    public void ReturnGame()
    {
        GameCanvas.SetActive(true);     //ゲームUIをtrueにする
        PauseCanvas.SetActive(false);   //ポーズUIをfalseにする
        PauseEnable = false;            //ポーズ状態のフラグをfalseにする
        PauseManager.TimeStart();       //ゲームの時間を通常の流れにする
        Debug.Log("ゲーム中");
    }


    //ステージの読み込み直し
    public void PauseRetryButton()
    {

        PauseManager.TimeStart();       //ゲームの時間を通常の流れにする

        //今のシーンを再ロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
