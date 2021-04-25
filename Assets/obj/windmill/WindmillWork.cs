using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillWork : MonoBehaviour
{

    BackData impeller_rotate_data;

    public float rotate_speed = 0.5f;

    public float fast_rotate = 1.0f;

    public float floor_move = 0.05f;

    public float fast_floor_move = 0.1f;

    public float max_floor = 8.0f;

    Transform inpeller_transform;
    Transform floorL_transform;
    Transform floorR_transform;
    Transform cordL_transform;
    Transform cordR_transform;
 

    // Start is called before the first frame update
    void Start()
    {
        impeller_rotate_data = new BackData();


        impeller_rotate_data.Init();


        //子オブジェクトのTransformの取得
        inpeller_transform = transform.GetChild(0).GetComponent<Transform>();
        floorR_transform = transform.GetChild(1).GetComponent<Transform>();
        floorL_transform = transform.GetChild(2).GetComponent<Transform>();
        cordL_transform = transform.GetChild(3).GetComponent<Transform>();
        cordR_transform = transform.GetChild(4).GetComponent<Transform>();

        //最大値の設定
        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -max_floor, 0.0f);
        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, max_floor, 1.0f);


    }

    // Update is called once per frame
    void Update()
    {

        //風の時だけ動く
        if (WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {

            float fl;

            switch (TimeManager.state)
            {
                case TimeManager.TimeState.TIME_BACK:
                    //回転
                    inpeller_transform.localEulerAngles = impeller_rotate_data.DataBack();

                    fl = 1.0f * floor_move;

                    //移動設定
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y - fl, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y + fl, 0.0f);
                    cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, cordL_transform.localScale.y + fl, 1.0f);
                    cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, cordR_transform.localScale.y - fl, 1.0f);

                    //上がる限界を超えたら
                    if (floorR_transform.localPosition.y >= -2.0f)
                    {
                        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -max_floor, 0.0f);
                        floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, -2.0f, 0.0f);
                        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, max_floor, 1.0f);
                        cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, 2.0f, 1.0f);
                    }

                    break;

                case TimeManager.TimeState.TIME_FAST:

                    //回転
                    inpeller_transform.Rotate(0.0f, 0.0f, -fast_rotate);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);

                    //移動値
                    fl = 1.0f * fast_floor_move;


                    //移動値設定
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y + fl, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y - fl, 0.0f);
                    cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, cordL_transform.localScale.y - fl, 1.0f);
                    cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, cordR_transform.localScale.y + fl, 1.0f);



                    //上がる限界を超えたら
                    if (floorL_transform.localPosition.y >= -2.0f)
                    {
                        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -2.0f, 0.0f);
                        floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, -max_floor, 0.0f);
                        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, 2.0f, 1.0f);
                        cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, max_floor, 1.0f);
                    }

                    break;

                case TimeManager.TimeState.TIME_PLAY:
                    //回転
                    inpeller_transform.Rotate(0.0f, 0.0f, -rotate_speed);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);


                    //移動値
                    fl = 1.0f * floor_move;


                    //移動値設定
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y + fl, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y - fl, 0.0f);
                    cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, cordL_transform.localScale.y - fl, 1.0f);
                    cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, cordR_transform.localScale.y + fl, 1.0f);

                    //上がる限界を超えたら
                    if (floorL_transform.localPosition.y >= -2.0f)
                    {
                        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -2.0f, 0.0f);
                        floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, - max_floor, 0.0f);
                        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, 2.0f, 1.0f);
                        cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, max_floor, 1.0f);
                    }



                    break;
                case TimeManager.TimeState.TIME_STOP:
                    break;
            }
        }
        //風が吹いていないとき
        else
        {
            float fl;

            if(TimeManager.state == TimeManager.TimeState.TIME_BACK)
            {
                //回転
                inpeller_transform.localEulerAngles = impeller_rotate_data.DataBack();

                fl = 1.0f * floor_move;

                //移動設定
                floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y - fl, 0.0f);
                floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y + fl, 0.0f);
                cordL_transform.localScale = new Vector3(1.0f, cordL_transform.localScale.y + fl, 1.0f);
                cordR_transform.localScale = new Vector3(1.0f, cordR_transform.localScale.y - fl, 1.0f);

                //上がる限界を超えたら
                if (floorR_transform.localPosition.y >= -2.0f)
                {
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -max_floor, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, - 2.0f, 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, max_floor, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
                }

            }

            //上にいる
            if (WindmilFloorLHit.isHitL == true)
            {


                fl = 1.0f * floor_move;

                //移動設定
                floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y - fl, 0.0f);
                floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y + fl, 0.0f);
                cordL_transform.localScale = new Vector3(1.0f, cordL_transform.localScale.y + fl, 1.0f);
                cordR_transform.localScale = new Vector3(1.0f, cordR_transform.localScale.y - fl, 1.0f);

                //上がる限界を超えたら
                if (floorR_transform.localPosition.y >= -2.0f)
                {
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -max_floor, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, - 2.0f, 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, max_floor, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
                }
                else
                {
                    //回転
                    inpeller_transform.Rotate(0.0f, 0.0f, rotate_speed);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);
                }


            }
            else if(WindmilFloorRHit.isHitR == true)
            {

                //移動値
                fl = 1.0f * floor_move;


                //移動値設定
                floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y + fl, 0.0f);
                floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y - fl, 0.0f);
                cordL_transform.localScale = new Vector3(1.0f, cordL_transform.localScale.y - fl, 1.0f);
                cordR_transform.localScale = new Vector3(1.0f, cordR_transform.localScale.y + fl, 1.0f);

                //上がる限界を超えたら
                if (floorL_transform.localPosition.y >= -2.0f)
                {
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -2.0f, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, - max_floor, 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, max_floor, 1.0f);
                }
                else
                {
                    //回転
                    inpeller_transform.Rotate(0.0f, 0.0f, -rotate_speed);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);
                }
            }
        }
    }

}
