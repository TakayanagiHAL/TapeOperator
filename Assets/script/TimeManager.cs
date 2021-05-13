using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{   
    public enum TimeState {
        TIME_PLAY,
        TIME_STOP,
        TIME_BACK,
        TIME_FAST,
        TIME_PAUSE
    };

    public static TimeState state;

    private int frame;

    private int day_count;

    public bool is_day;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = TimeState.TIME_PLAY;
        frame = 60 * 10;

        is_day = true;

        day_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);

        if (state == TimeState.TIME_PAUSE) return;

        if (frame > 0)
        {
            state = TimeState.TIME_PLAY;

            bool rt = Input.GetButton("FastForward");
            bool lt = Input.GetButton("Rewind");
            if (Input.GetKey(KeyCode.UpArrow) || (rt && lt)) 
            {
                state = TimeState.TIME_STOP;
                frame--;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {

            }
            if (Input.GetKey(KeyCode.RightArrow) || (rt && !lt))
            {
                state = TimeState.TIME_FAST;
                frame--;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || (!rt && lt))
            {
                state = TimeState.TIME_BACK;
                frame--;
            }
        }
        else
        {
            state = TimeState.TIME_PLAY;
        }

        day_count++;
        if (day_count >= 600)
        {
            if (is_day)
            {
                is_day = false;
            }
            else
            {
                is_day = true;
            }
            day_count = 0;
        }

        slider.SetValueWithoutNotify(frame);
    }

    
}

public class BackData
{
    public int current_data;

    public int old_data;

    public int flame;

    private static int data_count = 600;

    private Vector3[] back_data = new Vector3[data_count];

   public void Init()
    {
        for(int i = 0; i < data_count; i++)
        {
            back_data[i] = new Vector3();
        }
        current_data = 0;
        old_data = 0;
        flame = 0;
    }

    public void AddData(Vector3 data)
    {
        flame++;
        current_data++;
        current_data = current_data % data_count;

        if (current_data == old_data)
        {
            old_data++;
            old_data = old_data % data_count;
        }

        back_data[current_data] = data;

        //Debug.Log(back_data[current_data].position);
    }

    public Vector3 GetData()
    {
        return back_data[current_data];
    }

    public Vector3 DataBack()
    {
        flame--;
        current_data--;
        if (current_data < 0) current_data = data_count + current_data;

        if (current_data == old_data) current_data++;

        //Debug.Log(current_data);
       // Debug.Log(back_data[current_data].position);

        return back_data[current_data];
    }

    public void FillData(Vector3 data)
    {
        for(int i = 0; i < data_count; i++)
        {
            back_data[i] = data;
        }
    }
}
