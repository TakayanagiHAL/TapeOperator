using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmControl : MonoBehaviour
{
    private RectTransform[] filmholesback = new RectTransform[2];
    private RectTransform[] filmstrip = new RectTransform[2];
    private RectTransform[] filmholesfront = new RectTransform[2];
    private Image[] forward = new Image[2];
    private Image[] pause = new Image[2];
    private Image[] play = new Image[2];
    private Image[] rewind = new Image[2];

    //���͈̔�
    private float filmfront_width_left;
    private float filmback_width_left;
    private float filmfront_width_right;
    private float filmback_width_right;

    //�]���ȋ󔒂̌v�Z�p
    private float extra_holesback_width;
    private float extra_strip_width;
    private float extra_holesfront_width;

    //��鑬��
    public float film_speed;

    private TimeManager.TimeState old_time;


    // Start is called before the first frame update
    void Start()
    {
        RectTransform front = transform.GetChild(2).GetComponent<RectTransform>();
        RectTransform back = transform.GetChild(1).GetComponent<RectTransform>();
        RectTransform navi = transform.GetChild(5).GetComponent<RectTransform>();

        //���̕\���͈͂̎擾
        filmfront_width_left = front.position.x + (front.sizeDelta.x * (-1 * (front.lossyScale.x / 2)));
        filmfront_width_right = front.position.x + (front.sizeDelta.x * (front.lossyScale.x / 2));
        filmback_width_left = back.position.x + (back.sizeDelta.x * (-1 * (back.lossyScale.x / 2)));
        filmback_width_right = back.position.x + (back.sizeDelta.x * (back.lossyScale.x / 2));

        //���ꂼ��̎q�̎擾
        for (int i = 0; i < 2; i++)
        {
            filmholesback[i] = back.GetChild(i).GetComponent<RectTransform>();
            filmstrip[i] = front.GetChild(i).GetComponent<RectTransform>();
            filmholesfront[i] = front.GetChild(i + 2).GetComponent<RectTransform>();
            forward[i] = navi.GetChild(i * 4).GetComponent<Image>();
            pause[i] = navi.GetChild(i * 4 + 1).GetComponent<Image>();
            play[i] = navi.GetChild(i * 4 + 2).GetComponent<Image>();
            rewind[i] = navi.GetChild(i * 4 + 3).GetComponent<Image>();
        }

        old_time = TimeManager.state;

        //�]���ȕ��̌v�Z
        extra_holesback_width = filmholesback[0].sizeDelta.x * filmholesback[0].lossyScale.x - Mathf.Abs(filmholesback[1].position.x - filmholesback[0].position.x);
        extra_strip_width = filmstrip[0].sizeDelta.x * filmstrip[0].lossyScale.x - Mathf.Abs(filmstrip[1].position.x - filmstrip[0].position.x);
        extra_holesfront_width = filmholesfront[0].sizeDelta.x * filmholesfront[0].lossyScale.x - Mathf.Abs(filmholesfront[1].position.x - filmholesfront[0].position.x);

        film_speed = film_speed * this.transform.lossyScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:


                // �ړ��v�Z
                for (int i = 0; i < 2; i++)
                {
                    filmholesback[i].position = new Vector3(filmholesback[i].position.x - film_speed, filmholesback[i].position.y, filmholesback[i].position.z);
                    filmstrip[i].position = new Vector3(filmstrip[i].position.x + film_speed, filmstrip[i].position.y, filmstrip[i].position.z);
                    filmholesfront[i].position = new Vector3(filmholesfront[i].position.x + film_speed, filmholesfront[i].position.y, filmholesfront[i].position.z);

                    //���ꂼ��̒[�̌v�Z
                    float back = filmholesback[i].position.x + (filmholesback[i].sizeDelta.x * (filmholesback[i].lossyScale.x / 2));
                    float strip = filmstrip[i].position.x + (-1 * (filmstrip[i].sizeDelta.x * (filmstrip[i].lossyScale.x / 2)));
                    float front = filmholesfront[i].position.x + (-1 * (filmholesfront[i].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2)));

                    //filmholesback�̐ݒ�
                    //�\���͈͂𒴂����獶���Ɉړ�����
                    if (back < filmback_width_left)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesback[1].position.x + (filmholesback[1].sizeDelta.x * (filmholesback[i].lossyScale.x / 2)) - extra_holesback_width) +
                                         (filmholesback[0].sizeDelta.x * (filmholesback[0].lossyScale.x / 2));

                            filmholesback[0].position = new Vector3(fhb1, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesback[0].position.x + (filmholesback[0].sizeDelta.x * (filmholesback[i].lossyScale.x / 2)) - extra_holesback_width) +
                                         (filmholesback[1].sizeDelta.x * (filmholesback[1].lossyScale.x / 2));

                            filmholesback[1].position = new Vector3(fhb0, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                    }

                    //filmstrip�̐ݒ�
                    //�\���͈͂𒴂�����E���Ɉړ�����
                    if (strip > filmfront_width_right)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmstrip[1].position.x + (-1 * (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2))) + extra_strip_width) -
                                         (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2));

                            filmstrip[0].position = new Vector3(fhb1, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmstrip[0].position.x + (-1 * (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2))) + extra_strip_width) -
                                         (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2));

                            filmstrip[1].position = new Vector3(fhb0, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                    }
                    //filmholesfront�̐ݒ�
                    //�\���͈͂𒴂�����E���Ɉړ�����
                    if (front > filmfront_width_right)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesfront[1].position.x + (-1 * (filmholesfront[1].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2))) + extra_holesfront_width) -
                                         (filmholesfront[0].sizeDelta.x * (filmholesfront[0].lossyScale.x / 2));

                            filmholesfront[0].position = new Vector3(fhb1, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesfront[0].position.x + (-1 * (filmholesfront[0].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2))) + extra_holesfront_width) -
                                         (filmholesfront[1].sizeDelta.x * (filmholesfront[1].lossyScale.x / 2));

                            filmholesfront[1].position = new Vector3(fhb0, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                    }

                }

                break;
            case TimeManager.TimeState.TIME_FAST:


                //�ړ��v�Z
                for (int i = 0; i < 2; i++)
                {
                    filmholesback[i].position = new Vector3(filmholesback[i].position.x + film_speed * 2, filmholesback[i].position.y, filmholesback[i].position.z);
                    filmstrip[i].position = new Vector3(filmstrip[i].position.x - film_speed * 2, filmstrip[i].position.y, filmstrip[i].position.z);
                    filmholesfront[i].position = new Vector3(filmholesfront[i].position.x - film_speed * 2, filmholesfront[i].position.y, filmholesfront[i].position.z);

                    //���ꂼ��̒[�̌v�Z
                    float back = filmholesback[i].position.x + (-1 * (filmholesback[i].sizeDelta.x * (filmholesback[i].lossyScale.x / 2)));
                    float strip = filmstrip[i].position.x + (filmstrip[i].sizeDelta.x * (filmstrip[i].lossyScale.x / 2));
                    float front = filmholesfront[i].position.x + (filmholesfront[i].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2));

                    //filmholesback�̐ݒ�
                    //�\���͈͂𒴂�����E�����Ɉړ�����
                    if (back > filmback_width_right)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesback[1].position.x + (-1 * (filmholesback[1].sizeDelta.x * (filmholesback[i].lossyScale.x / 2))) + extra_holesback_width) -
                                         (filmholesback[0].sizeDelta.x * (filmholesback[0].lossyScale.x / 2));

                            filmholesback[0].position = new Vector3(fhb1, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesback[0].position.x + (-1 * (filmholesback[0].sizeDelta.x * (filmholesback[i].lossyScale.x / 2))) + extra_holesback_width) -
                                         (filmholesback[1].sizeDelta.x * (filmholesback[1].lossyScale.x / 2));

                            filmholesback[1].position = new Vector3(fhb0, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                    }

                    //filmstrip�̐ݒ�
                    //�\���͈͂𒴂����獶���Ɉړ�����
                    if (strip < filmfront_width_left)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmstrip[1].position.x + (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2)) - extra_strip_width) +
                                         (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2));

                            filmstrip[0].position = new Vector3(fhb1, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmstrip[0].position.x + (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2)) - extra_strip_width) +
                                         (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2));

                            filmstrip[1].position = new Vector3(fhb0, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                    }
                    //filmholesfront�̐ݒ�
                    //�\���͈͂𒴂����獶���Ɉړ�����
                    if (front < filmfront_width_left)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesfront[1].position.x + (filmholesfront[1].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2)) - extra_holesfront_width) +
                                         (filmholesfront[0].sizeDelta.x * (filmholesfront[0].lossyScale.x / 2));

                            filmholesfront[0].position = new Vector3(fhb1, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesfront[0].position.x + (filmholesfront[0].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2)) - extra_holesfront_width) +
                                         (filmholesfront[1].sizeDelta.x * (filmholesfront[1].lossyScale.x / 2));

                            filmholesfront[1].position = new Vector3(fhb0, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                    }


                }


                break;
            case TimeManager.TimeState.TIME_PLAY:


                //�ړ��v�Z
                for (int i = 0; i < 2; i++)
                {
                    filmholesback[i].position = new Vector3(filmholesback[i].position.x + film_speed, filmholesback[i].position.y, filmholesback[i].position.z);
                    filmstrip[i].position = new Vector3(filmstrip[i].position.x - film_speed, filmstrip[i].position.y, filmstrip[i].position.z);
                    filmholesfront[i].position = new Vector3(filmholesfront[i].position.x - film_speed, filmholesfront[i].position.y, filmholesfront[i].position.z);

                    //���ꂼ��̒[�̌v�Z
                    float back = filmholesback[i].position.x + (-1 * (filmholesback[i].sizeDelta.x * (filmholesback[i].lossyScale.x / 2)));
                    float strip = filmstrip[i].position.x + (filmstrip[i].sizeDelta.x * (filmstrip[i].lossyScale.x / 2));
                    float front = filmholesfront[i].position.x + (filmholesfront[i].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2));

                    //filmholesback�̐ݒ�
                    //�\���͈͂𒴂�����E�����Ɉړ�����
                    if (back > filmback_width_right)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesback[1].position.x + (-1 * (filmholesback[1].sizeDelta.x * (filmholesback[i].lossyScale.x / 2))) + extra_holesback_width) -
                                         (filmholesback[0].sizeDelta.x * (filmholesback[0].lossyScale.x / 2));

                            filmholesback[0].position = new Vector3(fhb1, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesback[0].position.x + (-1 * (filmholesback[0].sizeDelta.x * (filmholesback[i].lossyScale.x / 2))) + extra_holesback_width) -
                                         (filmholesback[1].sizeDelta.x * (filmholesback[1].lossyScale.x / 2));

                            filmholesback[1].position = new Vector3(fhb0, filmholesback[i].position.y, filmholesback[i].position.z);
                        }
                    }

                    //filmstrip�̐ݒ�
                    //�\���͈͂𒴂����獶���Ɉړ�����
                    if (strip < filmfront_width_left)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmstrip[1].position.x + (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2)) - extra_strip_width) +
                                         (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2));

                            filmstrip[0].position = new Vector3(fhb1, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmstrip[0].position.x + (filmstrip[0].sizeDelta.x * (filmstrip[0].lossyScale.x / 2)) - extra_strip_width) +
                                         (filmstrip[1].sizeDelta.x * (filmstrip[1].lossyScale.x / 2));

                            filmstrip[1].position = new Vector3(fhb0, filmstrip[i].position.y, filmstrip[i].position.z);
                        }
                    }
                    //filmholesfront�̐ݒ�
                    //�\���͈͂𒴂����獶���Ɉړ�����
                    if (front < filmfront_width_left)
                    {
                        //��Ԗڂ̂ق�
                        if (i == 0)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb1 = (filmholesfront[1].position.x + (filmholesfront[1].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2)) - extra_holesfront_width) +
                                         (filmholesfront[0].sizeDelta.x * (filmholesfront[0].lossyScale.x / 2));

                            filmholesfront[0].position = new Vector3(fhb1, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                        //2�Ԗڂ̂ق�
                        else if (i == 1)
                        {
                            //�ړ��ꏊ�̐ݒ�
                            float fhb0 = (filmholesfront[0].position.x + (filmholesfront[0].sizeDelta.x * (filmholesfront[i].lossyScale.x / 2)) - extra_holesfront_width) +
                                         (filmholesfront[1].sizeDelta.x * (filmholesfront[1].lossyScale.x / 2));

                            filmholesfront[1].position = new Vector3(fhb0, filmholesfront[i].position.y, filmholesfront[i].position.z);
                        }
                    }

                }

                break;
            case TimeManager.TimeState.TIME_STOP:

                break;
        }
        timechange();
        
    }



    void timechange()
    {

        if (TimeManager.state != old_time)
        {
            //off���
            if (old_time == TimeManager.TimeState.TIME_BACK)
            {
                rewind[0].gameObject.SetActive(false);
                rewind[1].gameObject.SetActive(true);
            }
            else if (old_time == TimeManager.TimeState.TIME_FAST)
            {
                forward[0].gameObject.SetActive(false);
                forward[1].gameObject.SetActive(true);
            }
            else if (old_time == TimeManager.TimeState.TIME_PLAY)
            {
                play[0].gameObject.SetActive(false);
                play[1].gameObject.SetActive(true);
            }
            else
            {
                pause[0].gameObject.SetActive(false);
                pause[1].gameObject.SetActive(true);
            }

            //on���
            if (TimeManager.state == TimeManager.TimeState.TIME_BACK)
            {
                rewind[0].gameObject.SetActive(true);
                rewind[1].gameObject.SetActive(false);
            }
            else if (TimeManager.state == TimeManager.TimeState.TIME_FAST)
            {
                forward[0].gameObject.SetActive(true);
                forward[1].gameObject.SetActive(false);
            }
            else if (TimeManager.state == TimeManager.TimeState.TIME_PLAY)
            {
                play[0].gameObject.SetActive(true);
                play[1].gameObject.SetActive(false);
            }
            else
            {
                pause[0].gameObject.SetActive(true);
                pause[1].gameObject.SetActive(false);
            }
            old_time = TimeManager.state;

        }
        else
        {
            return;
        }
    }


}
