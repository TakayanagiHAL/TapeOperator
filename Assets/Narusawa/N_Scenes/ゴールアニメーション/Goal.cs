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
        RUSSIA_1,
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
    [SerializeField] GameObject GameUI;
    [SerializeField] Fade fade;
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
        if(anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.End"))
        {
            if (!Fade.FadeStart)
            {
                if (Fade.FadeFinish)
                {
                    Fade.FadeFinish = false;
                    ScheneChanger.ChangeScene((int)ScheneChanger.SCENE_NAME.STAGE_SELECT);
                }
                else
                {
                    fade.StartFade();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            SoundPlayer.StopBGM();

            SoundPlayer.GetSoundManagaer().StopAllSe();

            SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Clear");

            Debug.Log("�S�[��");

            GameUI.SetActive(false);

            GoalPanel.SetActive(true);

            TimeManager.state = TimeManager.TimeState.TIME_PAUSE;

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
