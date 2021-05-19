using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 6.0F;       //���s���x
    public float JumpPower = 12.5f;   //�W�����v��
    public float gravity = 40.0F;    //�d�͂̑傫��
    public float Direction = 0.0f;   //�ړ�����
    public float IvyUpSpeed = 1.0f;
    private Vector3 YPower = Vector3.zero;    //y�������̏���
    private Vector3 moveDirection = Vector3.zero;   //�S�̂̈ړ�����
    private bool isJumpCheck = false;
    public bool isJump = false;
    public bool isClimb = false;




    private CharacterController controller;

    public Animator animator;

    private Framework.State.StateMachine<playercontroller> stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stateMachine = new Framework.State.StateMachine<playercontroller>();
        stateMachine.Initalize(new Player.State.Idle(), this);
    }

    // Update is called once per frame
    void Update()
    {

        InputKey_State();

        stateMachine.OnUpdate(this);
    }

    void FixedUpdate()
    {

        PlayerMovement();
    }


    /*-----------------------------------------
    �L�������ړ������Ɍ�����֐�
    ------------------------------------------*/
    void TurnRotation()
    {

        if (moveDirection != Vector3.zero)
        {
            //�L�����̌������ړ������ɍ��킹��
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

    }

    /*-------------------------------------------
      �L�[����
     --------------------------------------------*/
    void InputKey_State()
    {
        //�L�[�̒��l
        // �J�[�\���L�[�̓��͂��擾
        //�E�ړ�
        float Hori = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.D) || Hori > 0)
        {
            Direction = Input.GetAxis("Horizontal");

        }
        //���ړ�
        else if (Input.GetKey(KeyCode.A) || Hori < 0)
        {
            Direction = Input.GetAxis("Horizontal");
        }
        //�����ĂȂ��Ƃ�
        else
        {
            Direction = 0.0f;
        }

        if (controller.isGrounded)
        {
            //�W�����v
            //�������Ƃ�
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {  
                isJumpCheck = true;
            }
        }


    }

    /*-----------------------------------------
    �v���C���[�̈ړ�����
    ------------------------------------------*/
    void PlayerMovement()
    {
        moveDirection = Vector3.right * Direction;

        if(moveDirection.magnitude > 1f) moveDirection.Normalize();

        //�v���C���[�̌�����ς���
        TurnRotation();

        //�ړ��l�ݒ�
        moveDirection *= speed;

        //�n�ʂɂ���Ƃ�
        if (controller.isGrounded)
        {
            //�������Ƃ�
            if (isJumpCheck)
            {
                YPower.y = 0.0f;
                isJumpCheck = false;
                isJump = true;
                YPower.y += JumpPower * 1;

            }

        }
        //�n�ʂ��痣��Ă���Ƃ�
        else
        {
            if(YPower.y <= 0)
            {
                isJump = false;
            }
            //�d�͌v�Z
            YPower.y -= gravity * Time.deltaTime;


        }
       // Debug.Log(controller.isGrounded);
        controller.Move((moveDirection + YPower) * Time.deltaTime);

        Debug.Log(controller.isGrounded);
    }

}

