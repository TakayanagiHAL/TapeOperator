using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //本を閉じるアニメーションフラグをfalseにする
        animator.SetBool("CloseFlag", false);

    }
}
