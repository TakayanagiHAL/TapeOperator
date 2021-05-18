using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller1 : MonoBehaviour
{

    public float BaseJumpPower = 8.5f;   //�W�����v��
    public float GravityMultiplier = 10f;    //�d�͏搔
    public float MoveSpeed = 6f;    //�ړ�
    public float GroundCheckDistance = 0.1f;  //�������ւ̃��C�̒���
    public float jumpTime = 0.35f; //�W�����v����

    public float Direction = 0.0f; 
    private bool IsGrounded = false;  //
    private float OrigGroundCheckDistance;  
    private Vector3 GroundNormal;   

    private Transform CamPos;//
    private Vector3 move = Vector3.zero;//
    public bool isJump = false;//
    private bool isJumpingCheck = false;//
    private float jumpTimeCounter = 0.0f;//
    private float JumpPower = 0.0f;//
    private int jumpKey = 0;//
    public bool isClimb = false;//

    private Rigidbody rb;//
    private float PlayerHeight;//

   // public Animator animator;

  //  private Framework.State.StateMachine<playercontroller> stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerHeight = this.transform.lossyScale.y;
        OrigGroundCheckDistance = GroundCheckDistance;
        Debug.Log(PlayerHeight);

        //�J�����̃|�W�V�����擾
 
        CamPos = Camera.main.transform;
  
 
        isJump = false;

        //stateMachine = new Framework.State.StateMachine<playercontroller>();
       // stateMachine.Initalize(new Player.State.Idle(),this);
    }

    // Update is called once per frame
    void Update()
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

        //�W�����v
        //�������Ƃ�
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            jumpKey = 1;
        }
        //�����Ă��
        else if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
        {
            jumpKey = 2;
        }
        //�������Ƃ�
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump"))
        {
            jumpKey = 0;
        }


        /*------------------------------------------
          ���̓}�l�[�W���̐ݒ肩��̎擾
         --------------------------------------------*/
        ////// �J�[�\���L�[�̓��͂��擾
        //Direction = Input.GetAxis("Horizontal");
        ////�W�����v
        ////�������Ƃ�
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jumpKey = 1;
        //}
        ////�����Ă��
        //else if (Input.GetButton("Jump"))
        //{
        //    jumpKey = 2;
        //}
        ////�������Ƃ�
        //else if (Input.GetButtonUp("Jump"))
        //{
        //    jumpKey = 0;
        //}

        //stateMachine.OnUpdate(this);

       // Debug.Log(animator.GetInteger("NowState"));
    }

    void FixedUpdate()
    {
        //�ړ������ݒ�
        move = Direction * CamPos.right;

    
        
        //�n�ʓ����蔻��
        CheckGroundStatus();
        //�v���C���[�ړ�
        PlayerMovement();
    }

    /*-----------------------------------------
    �v���C���[�̈ړ�����
    ------------------------------------------*/
    private void PlayerMovement()
    {
        //���K��
        if (move.magnitude > 1f) move.Normalize();

        //�v���C���[�̌�����ς���
        TurnRotation();
        //���ʂɉ������x�N�g���̍쐬
        move = Vector3.ProjectOnPlane(move, GroundNormal);

        move.z = 0.0f;

        //�ړ��l�ݒ�
        rb.velocity = move * MoveSpeed + new Vector3(0.0f, rb.velocity.y, 0.0f);

        //�n�ʂɂ���Ƃ�
        if (IsGrounded)
        {
            //�������Ƃ�
            if (isJumpingCheck && jumpKey != 0)
            {
                jumpTimeCounter = jumpTime;
                isJumpingCheck = false;
                isJump= true;
                IsGrounded = false;
                JumpPower = BaseJumpPower;
            }

            //�n�ʂ܂ł̋����̐ݒ� 
            GroundCheckDistance = 0.1f;
        }
        //�n�ʂ��痣��Ă���Ƃ�
        else
        {
            //�������Ƃ�
            if (jumpKey == 0)
            {
                isJump = false;
            }
            //��������
            if (!isJump && !isClimb)
            {
                ////�d�͌v�Z
                //Vector3 extraGravityForce = (Physics.gravity * GravityMultiplier) - Physics.gravity;
                ////�d�͕�������
                //rb.AddForce(extraGravityForce);

                rb.useGravity = true;

                GroundCheckDistance = rb.velocity.y <= 0 ? OrigGroundCheckDistance : 0.01f;
            }



        }
        
        if (isJump)
        {
           
            jumpTimeCounter -= Time.deltaTime;
            //�����Ă�Ԃ̏���
            if (jumpKey == 2)
            { 
                JumpPower -= 0.2f;
                rb.velocity = new Vector3(rb.velocity.x, 1 * JumpPower, rb.velocity.z);
            }
            if (jumpTimeCounter < 0)
            {
                isJump = false;
            }
        }
        //�������Ƃ�
        if (jumpKey == 0)
        {
            isJumpingCheck = true;
        }


    }


    /*-----------------------------------------
    �L�������ړ������Ɍ�����֐�
    ------------------------------------------*/
    void TurnRotation()
    {
        
        if (move != Vector3.zero)
        {
            //�L�����̌������ړ������ɍ��킹��
            transform.rotation = Quaternion.LookRotation(move);
        }

    }


    /*-----------------------------------------
    �n�ʂ̓����蔻��
    ------------------------------------------*/
    private void CheckGroundStatus()
    {
        RaycastHit hitInfo;


        //Debug.DrawLine(transform.position + (Vector3.down * ((PlayerHeight / 2) - 0.01f)), transform.position + (Vector3.down * ((PlayerHeight / 2) - 0.01f)) + (Vector3.down * GroundCheckDistance), Color.red);
        if (Physics.Raycast(transform.position + (Vector3.down * ((PlayerHeight / 2) - 0.01f)), Vector3.down, out hitInfo, GroundCheckDistance))
        {
            GroundNormal = hitInfo.normal;
            IsGrounded = true;
            rb.useGravity =false;
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        }
        else
        {

            IsGrounded = false;
            GroundNormal = Vector3.up;
        }

    }

    //�w��̕��Ɠ������Ă����
    void OnCollisionStay(Collision other)
    {
        float Hori = Input.GetAxis("Vertical");
        //�ӂƓ������Ă���Ƃ�
        if (other.gameObject.tag == "ivy")
        {
            //W�L�[��������Ă�����
            if (Input.GetKey(KeyCode.W) || (Hori > 0))
            {
                isClimb = true;
            }
            //W�L�[��������Ă�����
            if (Input.GetKeyUp(KeyCode.W) || ((Hori <= 0) && isClimb))
            {
                isClimb = false;
            }

        }
    }
    //���ꂽ�Ƃ�
    void OnCollisionExit(Collision other)
    {
        //�ӂƓ������Ă���Ƃ�
        if (other.gameObject.tag == "ivy")
        {
            isClimb = false;
        }
    }

}
