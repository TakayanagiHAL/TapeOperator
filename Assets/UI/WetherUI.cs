using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WetherUI : MonoBehaviour
{

    public int now_wether;

    [SerializeField] float wether_age = 10;

    [SerializeField] WetherMark[] wetherMarks = new WetherMark[4];

    public Sprite[] back_sprite = new Sprite[4];

    public Sprite[] front_sprite = new Sprite[4];

    public Image back_image;

    public Image front_image;

    public WeatherManager_ver4 manager;

    // Start is called before the first frame update
    void Start()
    {
        now_wether = 0;

        back_image.sprite = back_sprite[0];
        front_image.sprite = front_sprite[0];

        wetherMarks[0].InitMark();
        wetherMarks[0].SetSprite(true);

        for(int i = 1; i < 4; i++)
        {
            wetherMarks[i].InitMark();
            wetherMarks[i].SetSprite(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(now_wether != manager.GetWeatherScheduleIndex())
        {
            wetherMarks[now_wether].SetSprite(false);
            now_wether = manager.GetWeatherScheduleIndex();

            back_image.sprite = back_sprite[now_wether];
            front_image.sprite = front_sprite[now_wether];

            wetherMarks[now_wether].SetSprite(true);
        }

        transform.rotation = Quaternion.Euler(0, 0, (90.0f * now_wether) + (manager.GetCurrentTime() * 90.0f/wether_age));
    }


}

public class Rotater
{
    private float r_speed;
    private float r_rad;
    public bool is_change;

    public void Init()
    {
        is_change = false;
    }

    public void SetRotate(float speed,float rad)
    {
        is_change = true;
        r_rad = rad;
        r_speed = speed;

        Debug.Log(rad);
    }

    public bool Rotate(Transform transform)
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, r_speed));

        if(r_rad == 360)
        {
            if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 10)
            {
                transform.rotation = Quaternion.Euler(0, 0, r_rad);

                is_change = false;
            }
        }

        if (transform.localEulerAngles.z > r_rad)
        {
            transform.rotation = Quaternion.Euler(0, 0, r_rad);

            is_change = false;
        }
        return is_change;
    }
}