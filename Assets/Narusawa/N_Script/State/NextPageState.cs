using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageState : StateMachineBehaviour
{
    //ステートに入ったとき
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //ページめくりのアニメーションフラグをfalseにする
        animator.SetBool("NextPageFlag", false);

        //本を開けるアニメーションフラグをfalseにする
        animator.SetBool("OpenFlag", false);

    }
}
