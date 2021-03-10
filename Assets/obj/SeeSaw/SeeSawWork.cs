using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawWork : MonoBehaviour
{
    BackData rotate_data;

    Renderer is_visible;

    // Start is called before the first frame update
    void Start()
    {
        rotate_data = new BackData();
        rotate_data.Init();
        is_visible = transform.GetChild(0).GetComponent<Renderer>();
        Debug.Log(is_visible);
    }

    // Update is called once per frame
    void Update()
    {
       if (!is_visible.isVisible) return;
        Debug.Log("update");
        Transform child = transform.GetChild(0).GetComponent<Transform>();
        Vector3 buff;
        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                child.localEulerAngles = rotate_data.DataBack();
                break;
            case TimeManager.TimeState.TIME_FAST:
                buff = child.localEulerAngles;
                rotate_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_PLAY:
                buff = child.localEulerAngles;
                rotate_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_STOP:
                child.localEulerAngles = rotate_data.GetData();
                Debug.Log("stop");
                break;
        }
    }
}
