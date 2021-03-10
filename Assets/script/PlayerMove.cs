using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;

    public float MoveSpeed = 15.0f;  //プレイヤーの動くスピード
    public float JumpMax = 5.0f;    //ジャンプの最大到達点
    public float JumpSpeed = 0.5f;  //ジャンプの移動値
    private bool JumpFlag = true;   //ジャンプフラグ
    private float JumpStartPos = 0.0f;  //ジャンプを始めた時のy座標

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
            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            //transform.position += moveForward * MoveSpeed;

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }

            //SPACEキーが押されている、ジャンプフラグがtrue、ポジションが最大到達点より低いとき、ジャンプする
            if (Input.GetKey(KeyCode.Space) && transform.position.y <= JumpStartPos + JumpMax && JumpFlag == true)
            {
                transform.position += new Vector3(0.0f, JumpSpeed, 0.0f);
            }

            //重力を足す
            rb.AddForce(moveForward * MoveSpeed);

        }

        //最大到達点を超えた場合、ジャンプしないようにフラグをfalseにする
        if (transform.position.y > JumpMax)
        {
            JumpFlag = false;
        }

    }

    void OnCollisionStay(Collision other)
    {
        //フィールドと当たっている間ジャンプするフラグをtrueにする
        if (other.gameObject.tag == "field")
        {
            JumpFlag = true;
            JumpStartPos = transform.position.y;
        }

    }
}
