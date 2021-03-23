using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���͊m�F�\��
        InputDemo();
    }


    //���͊m�F�\��
     private void InputDemo()
    {
        //�W�����v�{�^��
        //�R���g���[���[�FA�A�L�[�{�[�h�FSPACE
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }


        //������{�^��
        //�R���g���[���[�FRT�A�L�[�{�[�h�F�E���
        float R_Tri = Input.GetAxis("FastForward");
        if (R_Tri > 0)
        {
            Debug.Log("������:" + R_Tri);
        }


        //�����߂��{�^��
        //�R���g���[���[�FLT�A�L�[�{�[�h�F�����
        float L_Tri = Input.GetAxis("Rewind");
        if (L_Tri > 0)
        {
            Debug.Log("�����߂�:" + L_Tri);
        }


        //�Đ���~�{�^��
        //�L�[�{�[�h�F����
        if (Input.GetButtonDown("StartStop"))
        {
            Debug.Log("�Đ���~�؂�ւ�");
        }

        //��~�{�^��
        //�R���g���[���[�FRT��LT��������
        if (R_Tri > 0 && L_Tri > 0)
        {
            Debug.Log("��~");
        }


        //�I���{�^��
        //�R���g���[���[�FB�A�L�[�{�[�h�FENTER
        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("Select");
        }


        //�V��e�[�v�E�񂵃{�^��
        //�R���g���[���[�FRB�A�L�[�{�[�h�FE
        if (Input.GetButtonDown("TurnRight"))
        {
            Debug.Log("TurnRight");
        }


        //�V��e�[�v���񂵃{�^��
        //�R���g���[���[�FLB�A�L�[�{�[�h�FQ
        if (Input.GetButtonDown("TurnLeft"))
        {
            Debug.Log("TurnLeft");
        }


        //���j���[�{�^��
        //�R���g���[���[�FMENU�A�L�[�{�[�h�FESCAPE
        if (Input.GetButtonDown("Menu"))
        {
            Debug.Log("Menu");
        }


        //�v���C���[�ړ�
        //�R���g���[���[�F���X�e�B�b�N�A�L�[�{�[�h�FA,D
        float Hori = Input.GetAxis("Horizontal");
        if (Hori > 0)
        {
            Debug.Log("�E�ړ�");
        }
        else if (Hori < 0)
        {
            Debug.Log("���ړ�");
        }

    }
}
