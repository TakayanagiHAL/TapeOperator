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
        //�v���C���[��T��
       // Player = GameObject.Find("player");

        //�ʏ펞�̃L�����o�X��T��
       // Canvas = GameObject.Find("Canvas");

        //ButtonScript��T��
       // ButtonScript = GameObject.Find("ButtonScript");

        //�Q�[���I�[�o�[�L�����o�X���\���ɂ���
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Q�[���I�[�o�[UI�\��
    public void DispGameOver()
    {
        //�ʏ펞�̃L�����o�X���\���ɂ���
        Canvas.SetActive(false);

        //�Q�[���I�[�o�[�L�����o�X��\������
        GameOverCanvas.SetActive(true);

        //�v���C���[�̃A�j���[�V������Idle�ɂ���H


        //�v���C���[�̓������~�߂�
        Player.GetComponent<playercontroller>().enabled = false;
    }

    //�X�e�[�W�̓ǂݍ��ݒ���
    public void RetryButton()
    {
        //�v���C���[�𓮂���悤�ɂ���
        Player.GetComponent<playercontroller>().enabled = true;

        //�Q�[���̎��Ԃ�ʏ�̗���ɂ���
        PauseManager.TimeStart();

        //�ʏ펞�̃L�����o�X��\������
        Canvas.SetActive(true);

        //���̃V�[�����ă��[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
