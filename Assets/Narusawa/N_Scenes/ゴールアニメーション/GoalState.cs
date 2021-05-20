using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalState : StateMachineBehaviour
{
    private GameObject Goal;

    //ステートが終わったら
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.Find("Goal");

        //ScheneChanger.csの関数を呼び出す
        ScheneChanger.ChangeScene((int)ScheneChanger.SCENE_NAME.STAGE_SELECT);
    }
}
