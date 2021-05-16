using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePageState : StateMachineBehaviour
{
    //ステートに入ったとき
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //アニメーションフラグをfalseにする
        animator.SetBool("BeforePageFlag", false);

        //本を開けるアニメーションフラグをfalseにする
        animator.SetBool("OpenFlag", false);

    }
}
