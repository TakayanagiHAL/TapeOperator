using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum STAGE_NUM
    {
        EGYPT_1,
        EGYPT_2,
        EGYPT_3,
        EGYPT_4,
        EGYPT_5,
        STAGE6,
        STAGE7,
        STAGE8,
        STAGE9,
        STAGE10,
        STAGE_MAX
    }

    [SerializeField] STAGE_NUM ThisStageNum;    //���̃X�e�[�W�ԍ�
    [SerializeField] Camera MainCamera;         //���C���J����
    [SerializeField] Camera ClearCamera;        //�N���A���̃J����
    [SerializeField] GameObject GoalPanel;      //�S�[����UI�p�l��
    public static bool ColorFlag = false;       //�X�e�[�W�Z���N�g�̐F�t��
    public static int StageNum;                 //�X�e�[�W�ԍ�


    //UI�\������
    [SerializeField] GameObject GoalImage;

    private Animator anim;                 //Animator�擾�p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�S�[��UI��Animator�R���|�[�l���g��ݒ�
        anim = GoalImage.GetComponent<Animator>();

        //�X�e�[�W�̔ԍ����󂯓n���p�Ɏ擾
        StageNum = (int)ThisStageNum;

        ClearCamera.enabled = false;

        //�p�l����\��
        GoalPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("�S�[��");

            GoalPanel.SetActive(true);

            //�v���C���[�̃S�[���A�j���[�V����
            playercontroller player = other.GetComponent<playercontroller>();
            player.animator.SetBool("IsGoal", true);

            //�S�[��UI�̃A�j���[�V����
            anim.SetBool("Goal", true);

            //�J�����̐؂�ւ�
            ClearCamera.enabled = true;
            MainCamera.enabled = false;

            //�X�e�[�W�Z���N�g�̐F�t��
            ColorFlag = true;
        }
    }
}
