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
        //入力確認表示
        InputDemo();
    }


    //入力確認表示
     private void InputDemo()
    {
        //ジャンプボタン
        //コントローラー：A、キーボード：SPACE
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }


        //早送りボタン
        //コントローラー：RT、キーボード：右矢印
        float R_Tri = Input.GetAxis("FastForward");
        if (R_Tri > 0)
        {
            Debug.Log("早送り:" + R_Tri);
        }


        //巻き戻しボタン
        //コントローラー：LT、キーボード：左矢印
        float L_Tri = Input.GetAxis("Rewind");
        if (L_Tri > 0)
        {
            Debug.Log("巻き戻し:" + L_Tri);
        }


        //再生停止ボタン
        //キーボード：上矢印
        if (Input.GetButtonDown("StartStop"))
        {
            Debug.Log("再生停止切り替え");
        }

        //停止ボタン
        //コントローラー：RTとLT同時押し
        if (R_Tri > 0 && L_Tri > 0)
        {
            Debug.Log("停止");
        }


        //選択ボタン
        //コントローラー：B、キーボード：ENTER
        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("Select");
        }


        //天候テープ右回しボタン
        //コントローラー：RB、キーボード：E
        if (Input.GetButtonDown("TurnRight"))
        {
            Debug.Log("TurnRight");
        }


        //天候テープ左回しボタン
        //コントローラー：LB、キーボード：Q
        if (Input.GetButtonDown("TurnLeft"))
        {
            Debug.Log("TurnLeft");
        }


        //メニューボタン
        //コントローラー：MENU、キーボード：ESCAPE
        if (Input.GetButtonDown("Menu"))
        {
            Debug.Log("Menu");
        }


        //プレイヤー移動
        //コントローラー：左スティック、キーボード：A,D
        float Hori = Input.GetAxis("Horizontal");
        if (Hori > 0)
        {
            Debug.Log("右移動");
        }
        else if (Hori < 0)
        {
            Debug.Log("左移動");
        }

    }
}
