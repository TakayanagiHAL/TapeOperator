using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    BackData rotation_data;

    [SerializeField] float rotation_speed = 1.0f;
    [SerializeField] float fast_rotation = 2.0f;
    [SerializeField] Vector3 CenterPos;


    // Start is called before the first frame update
    void Start()
    {
        rotation_data = new BackData();
        rotation_data.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 buff;

        switch (TimeManager.state)
        {
            //transform.RotateAroundの第三引数を変えることで回転の速度変更可能

            case TimeManager.TimeState.TIME_BACK:
                transform.RotateAround(CenterPos, Vector3.forward, -fast_rotation);      //回転処理
                break;

            case TimeManager.TimeState.TIME_FAST:
                transform.RotateAround(CenterPos, Vector3.forward, fast_rotation);      //回転処理

                //データ保持
                //buff = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                //rotation_data.AddData(buff);

                break;

            case TimeManager.TimeState.TIME_PLAY:
                transform.RotateAround(CenterPos, Vector3.forward, rotation_speed);      //回転処理

                //buff = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                //rotation_data.AddData(buff);

                break;

            case TimeManager.TimeState.TIME_STOP:
                break;
        }
    }
}
