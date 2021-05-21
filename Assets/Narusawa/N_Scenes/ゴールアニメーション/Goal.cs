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

    [SerializeField] STAGE_NUM ThisStageNum;    //このステージ番号
    [SerializeField] Camera MainCamera;         //メインカメラ
    [SerializeField] Camera ClearCamera;        //クリア時のカメラ
    [SerializeField] GameObject GoalPanel;      //ゴールのUIパネル
    [SerializeField] GameObject GameUI;
    [SerializeField] Fade fade;
    public static bool ColorFlag = false;       //ステージセレクトの色付け
    public static int StageNum;                 //ステージ番号


    //UI表示処理
    [SerializeField] GameObject GoalImage;


    private Animator anim;                 //Animator取得用変数

    // Start is called before the first frame update
    void Start()
    {
        //ゴールUIのAnimatorコンポーネントを設定
        anim = GoalImage.GetComponent<Animator>();

        //ステージの番号を受け渡し用に取得
        StageNum = (int)ThisStageNum;

        ClearCamera.enabled = false;

        //パネル非表示
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

            Debug.Log("ゴール");

            GameUI.SetActive(false);

            GoalPanel.SetActive(true);

            TimeManager.state = TimeManager.TimeState.TIME_PAUSE;

            //プレイヤーのゴールアニメーション
            playercontroller player = other.GetComponent<playercontroller>();
            player.animator.SetBool("IsGoal", true);

            //ゴールUIのアニメーション
            anim.SetBool("Goal", true);

            //カメラの切り替え
            ClearCamera.enabled = true;
            MainCamera.enabled = false;

            //ステージセレクトの色付け
            ColorFlag = true;
        }
    }
}
