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
        RUSSIA_1,
        RUSSIA_2,
        RUSSIA_3,
        AFRICA_1,
        AFRICA_2,
        AFRICA_3,
        ANTARCTIC_1,
        ANTARCTIC_2,
        ANTARCTIC_3,
        AUSTRALIA_1,
        AUSTRALIA_2,
        AUSTRALIA_3,
        NORWAY_1,
        NORWAY_2,
        NORWAY_3,

        STAGE_MAX
    }

    [SerializeField] STAGE_NUM ThisStageNum;        //���̃X�e�[�W�ԍ�
    [SerializeField] Camera MainCamera;             //���C���J����
    [SerializeField] Camera ClearCamera;            //�N���A���̃J����
    [SerializeField] GameObject GoalPanel;          //�S�[����UI�p�l��
    public static bool[] ColorFlag = new bool[(int)STAGE_NUM.STAGE_MAX];      //�X�e�[�W�Z���N�g�̐F�t��
    //public static int StageNum;                   //�X�e�[�W�ԍ�


    //UI�\������
    [SerializeField] GameObject GoalImage;

    private Animator anim;                 //Animator�擾�p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�S�[��UI��Animator�R���|�[�l���g��ݒ�
        anim = GoalImage.GetComponent<Animator>();

        //�X�e�[�W�̔ԍ����󂯓n���p�Ɏ擾
        //StageNum = (int)ThisStageNum;

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

            SoundPlayer.StopBGM();
            SoundPlayer.GetSoundManagaer().StopAllSe();

            GoalPanel.SetActive(true);

            //�v���C���[�̃S�[���A�j���[�V����
            playercontroller player = other.GetComponent<playercontroller>();
            player.animator.SetBool("IsGoal", true);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1.0f);

            TimeManager.state = TimeManager.TimeState.TIME_PAUSE;

            //�S�[��UI�̃A�j���[�V����
            anim.SetBool("Goal", true);

            //�J�����̐؂�ւ�
            ClearCamera.enabled = true;
            MainCamera.enabled = false;

            //�X�e�[�W�Z���N�g�̐F�t��
            ColorFlag[(int)ThisStageNum] = true;
            Debug.Log(ThisStageNum + "��" + ColorFlag[(int)ThisStageNum]);
        }
        else
        {
            Debug.Log("other");
        }
    }
}
