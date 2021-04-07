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


    //Pauseシーンを呼ぶ関数
    public void PauseCall()
    {
        SceneManager.LoadScene("Pause");
    }


    //ステージ１を呼ぶ関数
    public void Stage1Call()
    {
        SceneManager.LoadScene("Stage1");
    }


    //ステージ２を呼ぶ関数
    public void Stage2Call()
    {
        SceneManager.LoadScene("Stage2");
    }
}
