using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Player;
   // [SerializeField] GameObject ButtonScript;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを探す
       // Player = GameObject.Find("player");

        //通常時のキャンバスを探す
       // Canvas = GameObject.Find("Canvas");

        //ButtonScriptを探す
       // ButtonScript = GameObject.Find("ButtonScript");

        //ゲームオーバーキャンバスを非表示にする
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームオーバーUI表示
    public void DispGameOver()
    {
        //通常時のキャンバスを非表示にする
        Canvas.SetActive(false);

        //ゲームオーバーキャンバスを表示する
        GameOverCanvas.SetActive(true);

        //プレイヤーのアニメーションをIdleにする？


        //プレイヤーの動きを止める
        Player.GetComponent<playercontroller>().enabled = false;
    }

    //ステージの読み込み直し
    public void RetryButton()
    {
        //プレイヤーを動けるようにする
        Player.GetComponent<playercontroller>().enabled = true;

        //ゲームの時間を通常の流れにする
        PauseManager.TimeStart();

        //通常時のキャンバスを表示する
        Canvas.SetActive(true);

        //今のシーンを再ロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
