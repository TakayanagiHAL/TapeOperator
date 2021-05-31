using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WaterRippleForScreens;

public class ZoomPhoto : MonoBehaviour
{
    //�Y�[���֘A
    [SerializeField] bool Zoom_Flag = true;             //�Y�[�����邩�̃t���O
    [SerializeField] GameObject MainCam;                //�Y�[������J����
    [SerializeField] float TargetDistance = 0.3f;       //�I�����ꂽ�ʐ^�Ƃ̋���
    [SerializeField] float ZoomTime = 1.0f;             //�Y�[���ɂ����鎞��
    [SerializeField] GameObject SceneChanger;           //ScheneChanger�������I�u�W�F�N�g���擾
    [SerializeField] GameObject PhotoSelect_obj;        //PhotoSelect�̂����I�u�W�F�N�g���擾
    [SerializeField] ScheneChanger.SCENE_NAME scene;    //�ǂݍ��ރV�[��
    static private bool ZoomStart_Flag = false;    //�Y�[�����n�߂�t���O
    private Vector3 Target;                 //�I�����ꂽ�ʐ^�̈ʒu�{Distance
    private Transform CamTns;               //�J������transform�擾�p
    private Vector3 velocity;               //�Y�[�����錻�݂̑��x

    //�g��֘A
    [SerializeField] float WaveTime = 3;        //�g��������鎞��
    [SerializeField] float MaxWaveScale = 60;

    //�X�e�[�W�ԍ���n��
    public static int StageNum;

    // Start is called before the first frame update
    void Start()
    {
        //�g�����X�t�H�[�����擾
        CamTns = MainCam.transform;

        //�^�[�Q�b�g�̐ݒ�
        Target = this.transform.position;
        Target.y += TargetDistance;

        ZoomStart_Flag = false;

    }

    // Update is called once per frame
    void Update()
    {
        //�Y�[��������
        if (Input.GetButtonDown("Select") && !ZoomStart_Flag)
        {
            if (scene == ScheneChanger.SCENE_NAME.SCENE_MAX) return;

            ZoomStart_Flag = true;

            SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Decision");

            Fade fade = GameObject.Find("Config").GetComponent<Fade>();

            fade.StartFade();
        }

        if (ZoomStart_Flag == true)
        {
            if (Zoom_Flag == true)
            {
                CamTns.position = Vector3.SmoothDamp(CamTns.position, Target, ref velocity, ZoomTime);

                if (CamTns.position.y <= Target.y + 0.03f)
                {
                    Debug.Log("�Y�[���I���");

                    

                    //�g��̕\��
                    Vector2 CamTarget = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                    MainCam.GetComponent<RippleEffect>().SetNewRipplePosition(CamTarget);

                    Invoke("SceneLoad", WaveTime);
                }
            }
            else
            {
                //���̃V�[����ǂݍ���
                StageNum = (int)scene;
                ScheneChanger.ChangeScene(StageNum);

                Fade.FadeFinish = false;
                Fade.FadeStart = false;

                ZoomStart_Flag = false;
            }
        }
        
    }

    void SceneLoad()
    {
        //���̃V�[����ǂݍ���
        StageNum = (int)scene;
        ScheneChanger.ChangeScene((int)scene);

        ZoomStart_Flag = false;
    }

    static public bool IsZoom()
    {
        return ZoomStart_Flag;
    }
}
