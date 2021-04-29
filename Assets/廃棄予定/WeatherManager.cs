using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    struct WeatherSchedule
    {
        public float Age;       //����
        public Weather weather; //�V�C
    }

    //�V�C�X�P�W���[��
    WeatherSchedule[] weatherschedule = new WeatherSchedule[] {
        new WeatherSchedule { Age = 100.0f, weather = Weather.SNOW },
        new WeatherSchedule { Age = 100.0f, weather = Weather.RAIN },
        new WeatherSchedule { Age = 100.0f, weather = Weather.SUNNY },
    };

    //������̔{��
    public float FastFeedRate = 1.5f;

    //�V�C�Ǘ��҃I�u�W�F�N�g�i�[
    GameObject WeatherAdministratorObject;

    //�V�C�Ǘ��҃I�u�W�F�N�g�X�N���v�g�i�[
    WeatherAdministrator WeatherAdministratorScript;

    //���݂̎���
    private float CurrentTime;

    //�V��Ǘ�����
    //���̓V��̎���
    private float WeatherManagerNextTime;

    //�O�̓V��̎���
    private float WeatherManagerPastTime;

    //�V��؂�ւ��t���O
    private bool ChangeoverFlag;

    //���݂̓V��X�P�W���[���̃C���f�b�N�X
    private int WeatherScheduleIndex;

    //�V��Ǝc�莞�ԕ\��
    public GameObject WeatherAndRemainTimeView = null;

    // Start is called before the first frame update
    void Start()
    {
        //�i�[
        WeatherAdministratorObject = GameObject.Find("WeatherAdministrator");
        WeatherAdministratorScript = WeatherAdministratorObject.GetComponent<WeatherAdministrator>();

        CurrentTime = 0.0f;
        WeatherScheduleIndex = 0;
        WeatherManagerNextTime = weatherschedule[WeatherScheduleIndex].Age;
        WeatherManagerPastTime = 0;
        ChangeoverFlag = false;
        //�V�C��ς���
        WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);
    }

    // Update is called once per frame
    void Update()
    {

        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_PLAY:
                //�J�E���g
                CurrentTime += Time.deltaTime;
                break;
            case TimeManager.TimeState.TIME_STOP:
                break;
            case TimeManager.TimeState.TIME_BACK:
                //�J�E���g
                CurrentTime -= Time.deltaTime;
                break;
            case TimeManager.TimeState.TIME_FAST:
                //�J�E���g
                CurrentTime += FastFeedRate * Time.deltaTime;
                break;
        }

        //�t�Đ��Ȃ�
        if (TimeManager.state == TimeManager.TimeState.TIME_BACK)
        {
            //�o�ߎ��Ԃ��؂�ւ����Ԃ𒴂�����
            if (WeatherManagerPastTime > CurrentTime)
            {
                //�؂�ւ��t���O�I���ɂ���
                ChangeoverFlag = true;
            }
        }
        else
        {
            //�o�ߎ��Ԃ��؂�ւ����Ԃ𒴂�����
            if (WeatherManagerNextTime < CurrentTime)
            {
                //�؂�ւ��t���O�I���ɂ���
                ChangeoverFlag = true;
            }
        }

        //�؂�ւ��t���O�I���Ȃ�
        if(ChangeoverFlag)
        {
            //�t�Đ��Ȃ�
            if (TimeManager.state == TimeManager.TimeState.TIME_BACK)
            {
                //�C���f�b�N�X���v�f���𒴂��Ȃ����
                if (WeatherScheduleIndex > 0)
                {
                    //�V�C�X�P�W���[���C���f�b�N�X���ւ炷
                    WeatherScheduleIndex--;
                }
                else
                {
                    //��������ő�ɂɂ���
                    WeatherScheduleIndex = weatherschedule.Length - 1;
                }

                //�V�C��ς���
                WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

                //���̐؂�ւ�鎞�Ԃ�ݒ�
                WeatherManagerNextTime = WeatherManagerPastTime;
                WeatherManagerPastTime -= weatherschedule[WeatherScheduleIndex].Age;

                //�؂�ւ��t���O�I�t�ɂ���
                ChangeoverFlag = false;
            }
            else
            {
                //�C���f�b�N�X���v�f���𒴂��Ȃ����
                if (WeatherScheduleIndex < weatherschedule.Length - 1)
                {
                    //�V�C�X�P�W���[���C���f�b�N�X�𑝂₷
                    WeatherScheduleIndex++;
                }
                else
                {
                    //��������ŏ��ɖ߂�
                    WeatherScheduleIndex = 0;
                }

                //�V�C��ς���
                WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

                //���̐؂�ւ�鎞�Ԃ�ݒ�
                WeatherManagerPastTime = WeatherManagerNextTime;
                WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

                //�؂�ւ��t���O�I�t�ɂ���
                ChangeoverFlag = false;
            }

        }

        
        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("TurnRight");
            WeatherScheduleIndex++;
            WeatherScheduleIndex %= 3;

            //�V�C��ς���
            WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

            //���̐؂�ւ�鎞�Ԃ�ݒ�
            WeatherManagerPastTime = WeatherManagerNextTime;
            WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

            //�؂�ւ��t���O�I�t�ɂ���
            ChangeoverFlag = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("TurnLeft"))
        {
            WeatherScheduleIndex--;

            if (WeatherScheduleIndex < 0) WeatherScheduleIndex = 2;

            //�V�C��ς���
            WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

            //���̐؂�ւ�鎞�Ԃ�ݒ�
            WeatherManagerPastTime = WeatherManagerNextTime;
            WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

            //�؂�ւ��t���O�I�t�ɂ���
            ChangeoverFlag = false;
        }

        //�e�L�X�g�\��
        //Text WeatherAndRemainTimeView_Text = WeatherAndRemainTimeView.GetComponent<Text>();
        //WeatherAndRemainTimeView_Text.text = "�V��" + weatherschedule[WeatherScheduleIndex].weather + "_�c�莞��" + (WeatherManagerNextTime - CurrentTime) + "_" + TimeManager.state;
    }
}
