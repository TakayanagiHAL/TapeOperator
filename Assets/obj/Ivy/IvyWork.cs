using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvyWork : MonoBehaviour
{
    BackData size_data;

    public float grow_size = 0.05f;

    public float fast_grow = 0.1f;

    public float max_glow = 10.0f;

    Renderer is_visible;

    // Start is called before the first frame update
    void Start()
    {
        size_data = new BackData();
        size_data.Init();
        is_visible = transform.GetChild(0).GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.isVisible) return;

        Vector3 buff;
        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_BACK:
                transform.localScale = size_data.DataBack();
                break;
            case TimeManager.TimeState.TIME_FAST:
                buff = new Vector3(transform.localScale.x, transform.localScale.y + fast_grow, transform.localScale.z);
                if (buff.y >= max_glow) buff.y = max_glow;
                transform.localScale = buff;
                size_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_PLAY:
                buff = new Vector3(transform.localScale.x, transform.localScale.y + grow_size, transform.localScale.z);
                if (buff.y >= max_glow) buff.y = max_glow;
                transform.localScale = buff;
                size_data.AddData(buff);
                break;
            case TimeManager.TimeState.TIME_STOP:
                break;
        }
    }
}
