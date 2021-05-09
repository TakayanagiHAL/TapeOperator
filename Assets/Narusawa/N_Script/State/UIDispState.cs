using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDispState : StateMachineBehaviour
{
    private GameObject Photoalbum;

    //ステートに入ったとき
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Photoalbum = GameObject.Find("Photoalbum");

        //PageChanger.csの関数を呼び出す
        Photoalbum.GetComponent<PageChanger>().CanvasDisp();

        //本を閉じるアニメーションフラグをfalseにする
        animator.SetBool("CloseFlag", false);
    }

}
