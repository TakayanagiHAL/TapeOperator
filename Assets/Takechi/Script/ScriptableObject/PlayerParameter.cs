using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    public float MoveSpeed;
    public float JumpMoveSpeed;
    public float GravityPower;
    public float JumpTime;
    public float BaseJumpPower;
}
