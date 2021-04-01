using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillWork : MonoBehaviour
{

    BackData impeller_rotate_data;

    public float rotate_speed = 0.5f;

    public float fast_rotate = 1.0f;

    BackData floorL_data;

    BackData floorR_data;

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
        floorL_data = new BackData();
        floorR_data = new BackData();

        impeller_rotate_data.Init();
        floorL_data.Init();
        floorR_data.Init();

        //�q�I�u�W�F�N�g��Transform�̎擾
        inpeller_transform = transform.GetChild(0).GetComponent<Transform>();
        floorR_transform = transform.GetChild(1).GetComponent<Transform>();
        floorL_transform = transform.GetChild(2).GetComponent<Transform>();
        cordL_transform = transform.GetChild(3).GetComponent<Transform>();
        cordR_transform = transform.GetChild(4).GetComponent<Transform>();

        //�ő�l�̐ݒ�
        floorL_transform.localPosition = new Vector3(-3.0f, -max_floor, 0.0f);
        cordL_transform.localScale = new Vector3(1.0f, max_floor, 1.0f);


    }

    // Update is called once per frame
    void Update()
    {

        //���̎���������
        if (WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {

            Vector3 fld;
            Vector3 frd;

            switch (TimeManager.state)
            {
                case TimeManager.TimeState.TIME_BACK:
                    //��]
                    inpeller_transform.localEulerAngles = impeller_rotate_data.DataBack();
                    //�ړ��l
                    fld = new Vector3(0.0f, floorL_data.DataBack().y, 0.0f);
                    frd = new Vector3(0.0f, floorR_data.DataBack().y, 0.0f);

                    //�ړ��ݒ�
                    floorL_transform.localPosition = new Vector3(-3.0f, -1.0f * fld.y, 0.0f);
                    floorR_transform.localPosition = new Vector3(3.0f, -1.0f * frd.y, 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, fld.y, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, frd.y, 1.0f);
                    break;
                case TimeManager.TimeState.TIME_FAST:

                    //��]
                    inpeller_transform.Rotate(0.0f, 0.0f, -fast_rotate);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);

                    //�ړ��l
                    fld = new Vector3(0.0f, cordL_transform.localScale.y - fast_floor_move, 0.0f);
                    frd = new Vector3(0.0f, cordR_transform.localScale.y + fast_floor_move, 0.0f);

                    //���E�l
                    if (fld.y <= 2.0f)
                    {
                        fld = new Vector3(0.0f, 2.0f, 0.0f);
                        frd = new Vector3(0.0f, max_floor, 0.0f);
                    }
                    //���E�łȂ���΃f�[�^�̕ێ�
                    else
                    {

                        floorL_data.AddData(fld);
                        floorR_data.AddData(frd);
                    }
                    //�ړ��l�ݒ�
                    floorL_transform.localPosition = new Vector3(-3.0f, -1.0f * (fld.y), 0.0f);
                    floorR_transform.localPosition = new Vector3(3.0f, -1.0f * (frd.y), 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, fld.y, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, frd.y, 1.0f);


                    break;
                case TimeManager.TimeState.TIME_PLAY:
                    //��]
                    inpeller_transform.Rotate(0.0f, 0.0f, -rotate_speed);
                    impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);

                    //�ړ��l
                    fld = new Vector3(0.0f, cordL_transform.localScale.y - floor_move, 0.0f);
                    frd = new Vector3(0.0f, cordR_transform.localScale.y + floor_move, 0.0f);

                    //���E�l
                    if (fld.y <= 2.0f)
                    {
                        fld = new Vector3(0.0f, 2.0f, 0.0f);
                        frd = new Vector3(0.0f, max_floor, 0.0f);
                    }
                    //���E�łȂ���΃f�[�^�̕ێ�
                    else
                    {

                        floorL_data.AddData(fld);
                        floorR_data.AddData(frd);
                    }
                    //�ړ��l�ݒ�
                    floorL_transform.localPosition = new Vector3(-3.0f, -1.0f * (fld.y), 0.0f);
                    floorR_transform.localPosition = new Vector3(3.0f, -1.0f * (frd.y), 0.0f);
                    cordL_transform.localScale = new Vector3(1.0f, fld.y, 1.0f);
                    cordR_transform.localScale = new Vector3(1.0f, frd.y, 1.0f);


                    break;
                case TimeManager.TimeState.TIME_STOP:
                    break;
            }
        }
        //���������Ă��Ȃ��Ƃ�
        else
        {
            Vector3 fld;
            Vector3 frd;

            //��ɂ���
            if (WindmilFloorLHit.isHitL == true)
            {
                //��]
                inpeller_transform.Rotate(0.0f, 0.0f, rotate_speed);
                impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);

                //�ړ��l
                fld = new Vector3(0.0f, cordL_transform.localScale.y + floor_move, 0.0f);
                frd = new Vector3(0.0f, cordR_transform.localScale.y - floor_move, 0.0f);

                //���E�l
                if (frd.y <= 2.0f)
                {
                    fld = new Vector3(0.0f, max_floor, 0.0f);
                    frd = new Vector3(0.0f, 2.0f, 0.0f);
                }
                //���E�łȂ���΃f�[�^�̕ێ�
                else
                {

                    floorL_data.AddData(fld);
                    floorR_data.AddData(frd);
                }
                //�ړ��l�ݒ�
                floorL_transform.localPosition = new Vector3(-3.0f, -1.0f * (fld.y), 0.0f);
                floorR_transform.localPosition = new Vector3(3.0f, -1.0f * (frd.y), 0.0f);
                cordL_transform.localScale = new Vector3(1.0f, fld.y, 1.0f);
                cordR_transform.localScale = new Vector3(1.0f, frd.y, 1.0f);



            }
            else if(WindmilFloorRHit.isHitR == true)
            {
                //��]
                inpeller_transform.Rotate(0.0f, 0.0f, -rotate_speed);
                impeller_rotate_data.AddData(inpeller_transform.localEulerAngles);

                //�ړ��l
                fld = new Vector3(0.0f, cordL_transform.localScale.y - floor_move, 0.0f);
                frd = new Vector3(0.0f, cordR_transform.localScale.y + floor_move, 0.0f);

                //���E�l
                if (fld.y < 2.0f)
                {
                    fld = new Vector3(0.0f, 2.0f, 0.0f);
                    frd = new Vector3(0.0f, max_floor, 0.0f);
                }
                else
                {

                    floorL_data.AddData(fld);
                    floorR_data.AddData(frd);
                }
                floorL_transform.localPosition = new Vector3(-3.0f, -1.0f * (fld.y), 0.0f);
                floorR_transform.localPosition = new Vector3(3.0f, -1.0f * (frd.y), 0.0f);
                cordL_transform.localScale = new Vector3(1.0f, fld.y, 1.0f);
                cordR_transform.localScale = new Vector3(1.0f, frd.y, 1.0f);
            }
        }
    }
}
