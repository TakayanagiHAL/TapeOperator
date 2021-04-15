using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
using UnityEngine.UI;

public class PoseManager : MonoBehaviour
{
    private TimeManager.TimeState store;

    [SerializeField] GameObject gButton1;
    [SerializeField] GameObject gButton2;
    [SerializeField] GameObject gButton3;


    // Start is called before the first frame update
    void Start()
    {
        gButton1.SetActive(false);
        gButton2.SetActive(false);
        gButton3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Timekeeper.instance.Clock("Pose").localTimeScale = 0.0f;
            store = TimeManager.state;
            TimeManager.state = TimeManager.TimeState.TIME_POSE;

            gButton1.SetActive(true);
            gButton2.SetActive(true);
            gButton3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Timekeeper.instance.Clock("Pose").localTimeScale = 1.0f;
            TimeManager.state = store;

            gButton1.SetActive(false);
            gButton2.SetActive(false);
            gButton3.SetActive(false);

        }
    }
}
