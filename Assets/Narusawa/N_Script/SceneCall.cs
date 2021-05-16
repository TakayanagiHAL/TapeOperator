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


    //Title�V�[�����ĂԊ֐�
    public void TitleCall()
    {
        SceneManager.LoadScene("Title");
    }


    //Pause�V�[�����ĂԊ֐�
    public void PauseCall()
    {
        SceneManager.LoadScene("Pause");
    }


    //�X�e�[�W�P���ĂԊ֐�
    public void Stage1Call()
    {
        SceneManager.LoadScene("Alpha sample");

        StageCounter.StageNumber = 1;
    }


    //�X�e�[�W�Q���ĂԊ֐�
    public void Stage2Call()
    {
        SceneManager.LoadScene("�EAlpha2 sample");
        StageCounter.StageNumber = 2;
    }


    //���g���C�{�^���p�֐�
    public void RetryButton()
    {
        //�X�e�[�W�ԍ��ɉ����ăX�e�[�W���Ă�
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
