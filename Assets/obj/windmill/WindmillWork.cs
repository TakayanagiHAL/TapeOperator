using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillWork : MonoBehaviour
{
    public IsInCamera is_visible;

    public float rotate_speed = 0.5f;

    public float floor_move = 0.05f;

    public float max_floor = 8.0f;

    Transform inpeller_transform;
    Transform floorL_transform;
    Transform floorR_transform;
    Transform cordL_transform;
    Transform cordR_transform;
 

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g��Transform�̎擾
        inpeller_transform = transform.GetChild(0).GetComponent<Transform>();
        floorR_transform = transform.GetChild(1).GetComponent<Transform>();
        floorL_transform = transform.GetChild(2).GetComponent<Transform>();
        cordL_transform = transform.GetChild(3).GetComponent<Transform>();
        cordR_transform = transform.GetChild(4).GetComponent<Transform>();

        //�ő�l�̐ݒ�
        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -max_floor, 0.0f);
        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, max_floor, 1.0f);


    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        //���̎���������
        if (WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {

            float fl;

                    //��]
                    inpeller_transform.Rotate(0.0f, 0.0f, -rotate_speed);

                    //�ړ��l
                    fl = 1.0f * floor_move;


                    //�ړ��l�ݒ�
                    floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, floorL_transform.localPosition.y + fl, 0.0f);
                    floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, floorR_transform.localPosition.y - fl, 0.0f);
                    cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, cordL_transform.localScale.y - fl, 1.0f);
                    cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, cordR_transform.localScale.y + fl, 1.0f);

                    //�オ����E�𒴂�����
                    if (floorL_transform.localPosition.y >= -2.0f)
                    {
                        floorL_transform.localPosition = new Vector3(floorL_transform.localPosition.x, -2.0f, 0.0f);
                        floorR_transform.localPosition = new Vector3(floorR_transform.localPosition.x, - max_floor, 0.0f);
                        cordL_transform.localScale = new Vector3(cordL_transform.localScale.x, 2.0f, 1.0f);
                        cordR_transform.localScale = new Vector3(cordR_transform.localScale.x, max_floor, 1.0f);
                    }
        }
       
    }

}
