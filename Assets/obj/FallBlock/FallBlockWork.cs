using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlockWork : MonoBehaviour
{
    BackData size_data;

    private Vector3 first_pos;

    public float fall_speed = 0.05f;

    public float fast_fall = 0.1f;

    public int fall_flame;

    private int flame;

    Renderer is_visible;

    // Start is called before the first frame update
    void Start()
    {
        size_data = new BackData();
        size_data.Init();
        first_pos = transform.position;
        is_visible = transform.GetChild(0).GetComponent<Renderer>();
        size_data.FillData(first_pos);
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.isVisible) return;

        Vector3 buff;
        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                transform.position = size_data.DataBack();
                break;
            case TimeManager.TimeState.TIME_FAST:
                transform.position -= transform.up * fast_fall;
                buff = transform.position;
                size_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_PLAY:
                transform.position -= transform.up * fall_speed;
                buff = transform.position;
                size_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_STOP:
                break;
        }
        flame++;

        if (flame > fall_flame)
        {
            transform.position = first_pos;
            flame = 0;
            size_data.Init();
            size_data.FillData(first_pos);
        }

        
    }
}
