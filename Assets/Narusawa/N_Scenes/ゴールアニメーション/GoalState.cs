using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalState : StateMachineBehaviour
{
    private GameObject Goal;

    //�X�e�[�g���I�������
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.Find("Goal");

        //ScheneChanger.cs�̊֐����Ăяo��
        ScheneChanger.ChangeScene((int)ScheneChanger.SCENE_NAME.STAGE_SELECT);
    }
}
