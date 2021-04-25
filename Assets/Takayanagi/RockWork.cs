using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWork : MonoBehaviour
{
    private bool is_visible;

    private BackData data;

    private Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {
        data = new BackData();
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible) return;

        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                this.transform.position = data.DataBack();
                break;

            case TimeManager.TimeState.TIME_FAST:
                data.AddData(this.transform.position);
                break;

            case TimeManager.TimeState.TIME_PLAY:
                data.AddData(this.transform.position);
                break;

            case TimeManager.TimeState.TIME_STOP:
                this.transform.position = data.GetData();
                break;
        }

        is_visible = false;
        body.useGravity = false;
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.tag == "MainCamera")
        {
            if (!is_visible)
            {
                is_visible = true;
                body.useGravity = true;
            }
        }
    }


}
