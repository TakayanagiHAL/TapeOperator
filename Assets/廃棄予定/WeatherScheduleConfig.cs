using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WeatherScheduleConfig")]
public class WeatherScheduleConfig : ScriptableObject
{
    public Weather[] weathers = new Weather[4];
}

