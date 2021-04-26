using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlockWork : MonoBehaviour
{
    BackData size_data;

    private Vector3 first_pos;

    public int fall_flame;

    private int flame;

    Renderer is_visible;

    Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {
        size_data = new BackData();
        size_data.Init();
        first_pos = transform.position;
        is_visible = GetComponent<Renderer>();
        size_data.FillData(first_pos);
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (!is_visible.isVisible) return;

        Vector3 buff;
        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                transform.position = size_data.DataBack();
               // flame++;
                break;
            case TimeManager.TimeState.TIME_FAST:
                buff = transform.position;
                size_data.AddData(buff);
                flame++;
                break;
            case TimeManager.TimeState.TIME_PLAY:
                buff = transform.position;
                size_data.AddData(buff);
                flame++;
                break;
            case TimeManager.TimeState.TIME_STOP:
                transform.position = size_data.GetData();
                break;
        }

        Debug.Log(flame);
        if (flame > fall_flame)
        {
            transform.position = first_pos;
            flame = 0;
            body.velocity = new Vector3(0, 0, 0);
            size_data.Init();
            size_data.FillData(first_pos);
        }

        
    }
}
