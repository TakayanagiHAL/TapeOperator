using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePageState : StateMachineBehaviour
{
    //�X�e�[�g�ɓ������Ƃ�
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //�A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("BeforePageFlag", false);

        //�{���J����A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("OpenFlag", false);

    }
}
