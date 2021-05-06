using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObjManager : MonoBehaviour
{
    public IsInCamera is_visible;

    public float move_speed = 0.0005f;    //�Đ����̓����X�s�[�h

    public float max_pos_y = 0.8698015f;     //�ő�ʒuY���W�i�I�u�W�F�N�g�̒��S�j


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        is_visible.is_visible = false;

        //�J�̎���������
        if (WeatherAdministrator.CurrentWeather == Weather.RAIN)
        {
            Vector3 buff;   //�ʒu�̉��ێ��p

                    //�ʒu�̉��ێ��p�Ɉړ���̒l������
                    buff = new Vector3(transform.position.x, transform.position.y + move_speed, transform.position.z);

                    //�ő�l�ُ�̏ꍇ�A�ő�l�ɂ���
                    if (buff.y >= max_pos_y) buff.y = max_pos_y;

                    //�|�W�V�����ɒl������
                    transform.position = buff;
            
        }
    }
}
