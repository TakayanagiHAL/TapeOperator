using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeManager : MonoBehaviour
{   
    public enum TimeState {
        TIME_PLAY,
        TIME_STOP,
        TIME_BACK,
        TIME_FAST,
        TIME_POSE
    };

    public static TimeState state;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = TimeState.TIME_PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == TimeState.TIME_POSE)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(state == TimeState.TIME_PLAY)
            {
                state = TimeState.TIME_STOP;

                Timekeeper.instance.Clock("obj").localTimeScale = 0.0f;
            }
            else
            {
                state = TimeState.TIME_PLAY;

                Timekeeper.instance.Clock("obj").localTimeScale = 1.0f;

            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            state = TimeState.TIME_FAST;

            Timekeeper.instance.Clock("obj").localTimeScale = 3.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            state = TimeState.TIME_BACK;

            Timekeeper.instance.Clock("obj").localTimeScale = -1.0f;
        }
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
}
