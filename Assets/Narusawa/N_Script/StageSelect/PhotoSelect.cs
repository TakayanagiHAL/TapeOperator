using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSelect : MonoBehaviour
{
    [SerializeField] GameObject[] Photos;       //�e�X�e�[�W�̎ʐ^��������z��
    [SerializeField] Vector3 SelectScale;       //�I��ł���ʐ^�̊g��
    [SerializeField] Material[] ClearMaterial;  //�N���A��̃}�e���A��
    private Vector3[] InitScale;                //�X�P�[���̏����l
    public static int SelectNum = 1;            //�I��ł���I�����̔ԍ�
    public static int PhotoMax = 5;             //1�y�[�W�̎ʐ^��
    private GameObject Page1;                   //�y�[�W1
    private GameObject Page2;                   //�؁[�W2
    private bool JoyInput = false;              //�W���C�X�e�B�b�N�̓��͎󂯕t��

    // Start is called before the first frame update
    void Start()
    {
        //������
        SelectNum = 1;
        JoyInput = false;

        //�I�����̍ő吔�����߂�
        PhotoMax = Photos.Length;

        //�������m��
        InitScale = new Vector3[Photos.Length];

        for (int i = 0; i < Photos.Length; i++)
        {
            //�V�[���؂�ւ��̃X�N���v�g����������I�t�ɂ���
            Photos[i].GetComponent<ZoomPhoto>().enabled = false;

            //�����l�̐ݒ�
            InitScale[i] += Photos[i].transform.localScale;
        }

        //�y�[�W���擾
        Page1 = GameObject.Find("Page1");
        Page2 = GameObject.Find("Page2");

        //�ŏ��ɑI��ł���I�����������傫������
        Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x, 
                                                             InitScale[SelectNum].y * SelectScale.y, 
                                                             InitScale[SelectNum].z * SelectScale.z);

        //�ŏ��ɑI��ł���I�����̃V�[���؂�ւ��X�N���v�g���I���ɂ���
        Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            JoyInput = false;
        }

        //���͂��󂯎��
        if (Input.GetKeyDown(KeyCode.D) || JoyInput == false && Input.GetAxisRaw("Horizontal") == 1) 
        {
            JoyInput = true;    //���͂���Ă���

            //���̓��͂őI�������𒴂��Ă��Ȃ��ꍇ���̑I������
            if (SelectNum < Photos.Length - 1)
            {

                //�T�C�Y�������l�ɖ߂�
                Photos[SelectNum].transform.localScale = InitScale[SelectNum];

                //�I��ł���I�����̃V�[���؂�ւ��X�N���v�g���I�t�ɂ���
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = false;

                //���̑I������
                SelectNum++;

                //�I��ł���ʐ^�������傫������
                Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x,
                                                                     InitScale[SelectNum].y * SelectScale.y,
                                                                     InitScale[SelectNum].z * SelectScale.z);

                //�I��ł���I�����̃V�[���؂�ւ��X�N���v�g���I���ɂ���
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || JoyInput == false && Input.GetAxisRaw("Horizontal") == -1)
        {
            JoyInput = true;    //���͂���Ă���

            //���̓��͂�0���傫���ꍇ�O�̑I������
            if (SelectNum >0)
            {
                //�T�C�Y�������l�ɖ߂�
                Photos[SelectNum].transform.localScale = InitScale[SelectNum];

                //�I��ł���I�����̃V�[���؂�ւ��X�N���v�g���I�t�ɂ���
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = false;

                //�O�̑I������
                SelectNum--;

                //�I��ł���ʐ^�������傫������
                Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x,
                                                                     InitScale[SelectNum].y * SelectScale.y,
                                                                     InitScale[SelectNum].z * SelectScale.z);

                //�I��ł���I�����̃V�[���؂�ւ��X�N���v�g���I���ɂ���
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;
            }
        }

        if (Goal.ColorFlag == true)
        {
            if (Goal.StageNum < 5)
            {
                Page1.GetComponent<PhotoSelect>().Photos[Goal.StageNum  + 1].GetComponent<Renderer>().material = ClearMaterial[Goal.StageNum];
                Debug.Log(Goal.StageNum);
            }else if (Goal.StageNum < 10)
            {
                Page2.GetComponent<PhotoSelect>().Photos[(Goal.StageNum / 5)].GetComponent<Renderer>().material = ClearMaterial[Goal.StageNum];
                Debug.Log(Goal.StageNum);
            }


        }
    }

    public void ResetScale()
    {
        //�X�P�[���̃��Z�b�g
        Photos[SelectNum].transform.localScale = InitScale[SelectNum];

        for (int i = 0; i < Photos.Length; i++)
        {
            //�V�[���؂�ւ��̃X�N���v�g����������I�t�ɂ���
            Photos[i].GetComponent<ZoomPhoto>().enabled = false;
        }

        //�ŏ��ɑI��ł���I�����������傫������
        Photos[1].transform.localScale = new Vector3(InitScale[1].x * SelectScale.x,
                                                     InitScale[1].y * SelectScale.y,
                                                     InitScale[1].z * SelectScale.z);

        //�ŏ��ɑI��ł���I�����̃V�[���؂�ւ��X�N���v�g���I���ɂ���
        Photos[1].GetComponent<ZoomPhoto>().enabled = true;
    }
}
