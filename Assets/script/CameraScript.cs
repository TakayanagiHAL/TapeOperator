using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject targetObj;    //追うターゲットのオブジェクトを受け取る変数
    Vector3 TargetPos;              //ターゲットのポジション保持用の変数

    void Start()
    {
        //プレイヤーのポジション保持
        TargetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - TargetPos;
        TargetPos = targetObj.transform.position;

    }
}
