using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //ExitButtonが押された時に呼ぶ関数
    public void ExitButton()
    {
        Application.Quit();
    }


    //StageSelectシーンを呼ぶ関数
    public void StageSelectCall()
    {
        SceneManager.LoadScene("StageSelect");
    }


    //Titleシーンを呼ぶ関数
    public void TitleCall()
    {
        SceneManager.LoadScene("Title");
    }


    //Pauseシーンを呼ぶ関数
    public void PauseCall()
    {
        SceneManager.LoadScene("Pause");
    }


    //ステージ１を呼ぶ関数
    public void Stage1Call()
    {
        SceneManager.LoadScene("Alpha sample");

        StageCounter.StageNumber = 1;
    }


    //ステージ２を呼ぶ関数
    public void Stage2Call()
    {
        SceneManager.LoadScene("・Alpha2 sample");
        StageCounter.StageNumber = 2;
    }


    //リトライボタン用関数
    public void RetryButton()
    {
        //ステージ番号に応じてステージを呼ぶ
        switch (StageCounter.StageNumber)
        {
            case 1:
                Stage1Call();
                break;

            case 2:
                Stage2Call();
                break;

            default:
                break;
        }

    }
}
