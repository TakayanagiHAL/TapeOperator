using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageState : StateMachineBehaviour
{
    //�X�e�[�g�ɓ������Ƃ�
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //�y�[�W�߂���̃A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("NextPageFlag", false);

        //�{���J����A�j���[�V�����t���O��false�ɂ���
        animator.SetBool("OpenFlag", false);

    }
}
