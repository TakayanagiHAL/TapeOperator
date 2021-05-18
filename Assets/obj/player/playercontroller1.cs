using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller1 : MonoBehaviour
{

    public float BaseJumpPower = 8.5f;   //ジャンプ力
    public float GravityMultiplier = 10f;    //重力乗数
    public float MoveSpeed = 6f;    //移動
    public float GroundCheckDistance = 0.1f;  //下方向へのレイの長さ
    public float jumpTime = 0.35f; //ジャンプ時間

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

        //カメラのポジション取得
 
        CamPos = Camera.main.transform;
  
 
        isJump = false;

        //stateMachine = new Framework.State.StateMachine<playercontroller>();
       // stateMachine.Initalize(new Player.State.Idle(),this);
    }

    // Update is called once per frame
    void Update()
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

        //ジャンプ
        //押したとき
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            jumpKey = 1;
        }
        //押してる間
        else if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
        {
            jumpKey = 2;
        }
        //離したとき
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump"))
        {
            jumpKey = 0;
        }


        /*------------------------------------------
          入力マネージャの設定からの取得
         --------------------------------------------*/
        ////// カーソルキーの入力を取得
        //Direction = Input.GetAxis("Horizontal");
        ////ジャンプ
        ////押したとき
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jumpKey = 1;
        //}
        ////押してる間
        //else if (Input.GetButton("Jump"))
        //{
        //    jumpKey = 2;
        //}
        ////離したとき
        //else if (Input.GetButtonUp("Jump"))
        //{
        //    jumpKey = 0;
        //}

        //stateMachine.OnUpdate(this);

       // Debug.Log(animator.GetInteger("NowState"));
    }

    void FixedUpdate()
    {
        //移動方向設定
        move = Direction * CamPos.right;

    
        
        //地面当たり判定
        CheckGroundStatus();
        //プレイヤー移動
        PlayerMovement();
    }

    /*-----------------------------------------
    プレイヤーの移動処理
    ------------------------------------------*/
    private void PlayerMovement()
    {
        //正規化
        if (move.magnitude > 1f) move.Normalize();

        //プレイヤーの向きを変える
        TurnRotation();
        //平面に沿ったベクトルの作成
        move = Vector3.ProjectOnPlane(move, GroundNormal);

        move.z = 0.0f;

        //移動値設定
        rb.velocity = move * MoveSpeed + new Vector3(0.0f, rb.velocity.y, 0.0f);

        //地面にいるとき
        if (IsGrounded)
        {
            //押したとき
            if (isJumpingCheck && jumpKey != 0)
            {
                jumpTimeCounter = jumpTime;
                isJumpingCheck = false;
                isJump= true;
                IsGrounded = false;
                JumpPower = BaseJumpPower;
            }

            //地面までの距離の設定 
            GroundCheckDistance = 0.1f;
        }
        //地面から離れているとき
        else
        {
            //離したとき
            if (jumpKey == 0)
            {
                isJump = false;
            }
            //落下処理
            if (!isJump && !isClimb)
            {
                ////重力計算
                //Vector3 extraGravityForce = (Physics.gravity * GravityMultiplier) - Physics.gravity;
                ////重力分下げる
                //rb.AddForce(extraGravityForce);

                rb.useGravity = true;

                GroundCheckDistance = rb.velocity.y <= 0 ? OrigGroundCheckDistance : 0.01f;
            }



        }
        
        if (isJump)
        {
           
            jumpTimeCounter -= Time.deltaTime;
            //押してる間の処理
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
        //離したとき
        if (jumpKey == 0)
        {
            isJumpingCheck = true;
        }


    }


    /*-----------------------------------------
    キャラを移動方向に向ける関数
    ------------------------------------------*/
    void TurnRotation()
    {
        
        if (move != Vector3.zero)
        {
            //キャラの向きを移動方向に合わせる
            transform.rotation = Quaternion.LookRotation(move);
        }

    }


    /*-----------------------------------------
    地面の当たり判定
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

    //指定の物と当たっている間
    void OnCollisionStay(Collision other)
    {
        float Hori = Input.GetAxis("Vertical");
        //蔦と当たっているとき
        if (other.gameObject.tag == "ivy")
        {
            //Wキーが押されていたら
            if (Input.GetKey(KeyCode.W) || (Hori > 0))
            {
                isClimb = true;
            }
            //Wキーが押されていたら
            if (Input.GetKeyUp(KeyCode.W) || ((Hori <= 0) && isClimb))
            {
                isClimb = false;
            }

        }
    }
    //離れたとき
    void OnCollisionExit(Collision other)
    {
        //蔦と当たっているとき
        if (other.gameObject.tag == "ivy")
        {
            isClimb = false;
        }
    }

}
