using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/LightConfig")]
public class LightConfig : ScriptableObject
{
    public float SunNum;
    public float RainNum;
    public float SnowNum;
    public float StormyNum;
    public float BlizzardNum;
}
