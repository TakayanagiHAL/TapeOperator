using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFloorWork : MonoBehaviour
{
    private BackData rotate_data;

    public float rotate_speed = 0.05f;

    public float fast_rotate = 0.1f;


    Renderer is_visible;
    // Start is called before the first frame update
    void Start()
    {
        rotate_data = new BackData();
        rotate_data.Init();
        is_visible = transform.GetChild(0).GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.isVisible) return;

        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                transform.localEulerAngles = rotate_data.DataBack();
                break;
            case TimeManager.TimeState.TIME_FAST:
                transform.Rotate(0, 0, fast_rotate);
                rotate_data.AddData(transform.localEulerAngles);
                break;
            case TimeManager.TimeState.TIME_PLAY:
                transform.Rotate(0, 0, rotate_speed);
                rotate_data.AddData(transform.localEulerAngles);
                break;
            case TimeManager.TimeState.TIME_STOP:
                break;
        }
    }
}
