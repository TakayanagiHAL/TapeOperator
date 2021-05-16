using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDispState : StateMachineBehaviour
{
    private GameObject Photoalbum;

    //�X�e�[�g�ɓ������Ƃ�
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Photoalbum = GameObject.Find("Photoalbum");

        //PageChanger.cs�̊֐����Ăяo��
        Photoalbum.GetComponent<PageChanger>().CanvasDisp();

        //�{�����A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("CloseFlag", false);
    }

}
