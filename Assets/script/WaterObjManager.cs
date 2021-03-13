using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObjManager : MonoBehaviour
{

    BackData pos_data;     //�ʒu���L�^�p

    public float move_speed = 0.0005f;    //�Đ����̓����X�s�[�h

    public float fast_move = 0.01f;      //�����莞�̓����X�s�[�h

    public float max_pos_y = 0.8698015f;     //�ő�ʒuY���W�i�I�u�W�F�N�g�̒��S�j


    // Start is called before the first frame update
    void Start()
    {
        pos_data = new BackData();
        pos_data.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //�J�̎���������
        if (WeatherAdministrator.CurrentWeather == Weather.RAIN)
        {
            Vector3 buff;   //�ʒu�̉��ێ��p


            switch (TimeManager.state)
            {
                case TimeManager.TimeState.TIME_BACK:
                    transform.position = pos_data.DataBack();

                    break;

                case TimeManager.TimeState.TIME_FAST:
                    //�ʒu�̉��ێ��p�Ɉړ���̒l������
                    buff = new Vector3(transform.position.x, transform.position.y + fast_move, transform.position.z);

                    //�ő�l�ُ�̏ꍇ�A�ő�l�ɂ���
                    if (buff.y >= max_pos_y) buff.y = max_pos_y;

                    //�|�W�V�����ɒl������
                    transform.position = buff;

                    //�ʒu����ۑ����Ă���
                    pos_data.AddData(buff);

                    break;

                case TimeManager.TimeState.TIME_PLAY:
                    //�ʒu�̉��ێ��p�Ɉړ���̒l������
                    buff = new Vector3(transform.position.x, transform.position.y + move_speed, transform.position.z);

                    //�ő�l�ُ�̏ꍇ�A�ő�l�ɂ���
                    if (buff.y >= max_pos_y) buff.y = max_pos_y;

                    //�|�W�V�����ɒl������
                    transform.position = buff;

                    //�ʒu����ۑ����Ă���
                    pos_data.AddData(buff);

                    break;

                case TimeManager.TimeState.TIME_STOP:
                    break;
            }
        }
    }
}
