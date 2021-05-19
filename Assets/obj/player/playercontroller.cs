using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 6.0F;       //歩行速度
    public float JumpPower = 12.5f;   //ジャンプ力
    public float gravity = 40.0F;    //重力の大きさ
    public float Direction = 0.0f;   //移動方向
    public float IvyUpSpeed = 1.0f;
    private Vector3 YPower = Vector3.zero;    //y軸方向の処理
    private Vector3 moveDirection = Vector3.zero;   //全体の移動方向
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
    キャラを移動方向に向ける関数
    ------------------------------------------*/
    void TurnRotation()
    {

        if (moveDirection != Vector3.zero)
        {
            //キャラの向きを移動方向に合わせる
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

    }

    /*-------------------------------------------
      キー入力
     --------------------------------------------*/
    void InputKey_State()
    {
        //キーの直値
        // カーソルキーの入力を取得
        //右移動
        float Hori = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.D) || Hori > 0)
        {
            Direction = Input.GetAxis("Horizontal");

        }
        //左移動
        else if (Input.GetKey(KeyCode.A) || Hori < 0)
        {
            Direction = Input.GetAxis("Horizontal");
        }
        //押してないとき
        else
        {
            Direction = 0.0f;
        }

        if (controller.isGrounded)
        {
            //ジャンプ
            //押したとき
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {  
                isJumpCheck = true;
            }
        }


    }

    /*-----------------------------------------
    プレイヤーの移動処理
    ------------------------------------------*/
    void PlayerMovement()
    {
        moveDirection = Vector3.right * Direction;

        if(moveDirection.magnitude > 1f) moveDirection.Normalize();

        //プレイヤーの向きを変える
        TurnRotation();

        //移動値設定
        moveDirection *= speed;

        //地面にいるとき
        if (controller.isGrounded)
        {
            //押したとき
            if (isJumpCheck)
            {
                YPower.y = 0.0f;
                isJumpCheck = false;
                isJump = true;
                YPower.y += JumpPower * 1;

            }

        }
        //地面から離れているとき
        else
        {
            if(YPower.y <= 0)
            {
                isJump = false;
            }
            //重力計算
            YPower.y -= gravity * Time.deltaTime;


        }
       // Debug.Log(controller.isGrounded);
        controller.Move((moveDirection + YPower) * Time.deltaTime);

        Debug.Log(controller.isGrounded);
    }

}

