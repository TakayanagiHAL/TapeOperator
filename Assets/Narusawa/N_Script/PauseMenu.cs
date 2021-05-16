using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject GameCanvas;      //�Q�[��UI�̃p�l��
    [SerializeField] GameObject PauseCanvas;     //�|�[�YUI�̃p�l��
    public static bool PauseEnable = false;      //�|�[�Y��Ԃ��̃t���O


    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.SetActive(true);       //�Q�[��UI��true�ɂ���
        PauseCanvas.SetActive(false);     //�|�[�YUI��false�ɂ���
        PauseEnable = false;    //�Q�[����Ԃɂ���
    }


    // Update is called once per frame
    void Update()
    {
        //���j���[�{�^���������ꂽ��
        if (Input.GetButtonDown("Menu"))
        {
            PauseEnable = !PauseEnable;     //�|�[�Y��Ԃ̃t���O��؂�ւ���

            if (PauseEnable == true)    //�|�[�Y��
            {
                GameCanvas.SetActive(false);    //�Q�[��UI��false�ɂ���
                PauseCanvas.SetActive(true);    //�|�[�YUI��true�ɂ���
                PauseManager.TimeStop();        //�Q�[���̎��Ԃ��~�߂�
                Debug.Log("�|�[�Y��");
            }
            else
            {
                ReturnGame();
            }

        }
    }

    //Pause����Game�ɖ߂�֐�
    public void ReturnGame()
    {
        GameCanvas.SetActive(true);     //�Q�[��UI��true�ɂ���
        PauseCanvas.SetActive(false);   //�|�[�YUI��false�ɂ���
        PauseEnable = false;            //�|�[�Y��Ԃ̃t���O��false�ɂ���
        PauseManager.TimeStart();       //�Q�[���̎��Ԃ�ʏ�̗���ɂ���
        Debug.Log("�Q�[����");
    }


    //�X�e�[�W�̓ǂݍ��ݒ���
    public void PauseRetryButton()
    {

        PauseManager.TimeStart();       //�Q�[���̎��Ԃ�ʏ�̗���ɂ���

        //���̃V�[�����ă��[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
