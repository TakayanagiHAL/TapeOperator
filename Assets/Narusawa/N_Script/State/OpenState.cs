using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //�{�����A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("CloseFlag", false);

    }
}
