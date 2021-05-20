using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterRippleForScreens;

public class WaveSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wave_Spawn()
    {
        Camera cam = Camera.main;

        Vector2 target = new Vector2(0.0f,0.0f);
        target = cam.WorldToScreenPoint(target);
        target.y = Screen.height - target.y;
        cam.GetComponent<RippleEffect>().SetNewRipplePosition(target);
    }
}
