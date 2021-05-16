using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WeatherScheduleConfig")]
public class WeatherScheduleConfig_ver2 : ScriptableObject
{
    public Weather[] weathers = new Weather[4];
    public float[] age = new float[4];
}

