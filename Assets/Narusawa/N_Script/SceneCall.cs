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


    //ExitButton�������ꂽ���ɌĂԊ֐�
    public void ExitButton()
    {
        Application.Quit();
    }


    //StageSelect�V�[�����ĂԊ֐�
    public void StageSelectCall()
    {
        SceneManager.LoadScene("StageSelect");
    }


    //Pause�V�[�����ĂԊ֐�
    public void PauseCall()
    {
        SceneManager.LoadScene("Pause");
    }


    //�X�e�[�W�P���ĂԊ֐�
    public void Stage1Call()
    {
        SceneManager.LoadScene("Stage1");
    }


    //�X�e�[�W�Q���ĂԊ֐�
    public void Stage2Call()
    {
        SceneManager.LoadScene("Stage2");
    }
}
