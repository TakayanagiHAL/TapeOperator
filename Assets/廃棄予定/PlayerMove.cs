using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;

    public float MoveSpeed = 15.0f;  //�v���C���[�̓����X�s�[�h
    public float JumpMax = 5.0f;    //�W�����v�̍ő哞�B�_
    public float JumpSpeed = 0.5f;  //�W�����v�̈ړ��l
    private bool JumpFlag = true;   //�W�����v�t���O
    private float JumpStartPos = 0.0f;  //�W�����v���n�߂�����y���W

    void Start()
    {
        JumpFlag = true;
    }


    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.Space))
        {
            // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            //transform.position += moveForward * MoveSpeed;

            // �L�����N�^�[�̌�����i�s������
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }

            //SPACE�L�[��������Ă���A�W�����v�t���O��true�A�|�W�V�������ő哞�B�_���Ⴂ�Ƃ��A�W�����v����
            if (Input.GetKey(KeyCode.Space) && transform.position.y <= JumpStartPos + JumpMax && JumpFlag == true)
            {
                transform.position += new Vector3(0.0f, JumpSpeed, 0.0f);
            }

            //�d�͂𑫂�
            rb.AddForce(moveForward * MoveSpeed);

        }

        //�ő哞�B�_�𒴂����ꍇ�A�W�����v���Ȃ��悤�Ƀt���O��false�ɂ���
        if (transform.position.y > JumpMax)
        {
            JumpFlag = false;
        }

    }

    void OnCollisionStay(Collision other)
    {
        //�t�B�[���h�Ɠ������Ă���ԃW�����v����t���O��true�ɂ���
        if (other.gameObject.tag == "field")
        {
            JumpFlag = true;
            JumpStartPos = transform.position.y;
        }

    }
}
