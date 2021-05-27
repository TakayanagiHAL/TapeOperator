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

    [SerializeField] STAGE_NUM ThisStageNum;        //このステージ番号
    [SerializeField] Camera MainCamera;             //メインカメラ
    [SerializeField] Camera ClearCamera;            //クリア時のカメラ
    [SerializeField] GameObject GoalPanel;          //ゴールのUIパネル
    public static bool[] ColorFlag = new bool[(int)STAGE_NUM.STAGE_MAX];      //ステージセレクトの色付け
    //public static int StageNum;                   //ステージ番号


    //UI表示処理
    [SerializeField] GameObject GoalImage;

    private Animator anim;                 //Animator取得用変数

    // Start is called before the first frame update
    void Start()
    {
        //ゴールUIのAnimatorコンポーネントを設定
        anim = GoalImage.GetComponent<Animator>();

        //ステージの番号を受け渡し用に取得
        //StageNum = (int)ThisStageNum;

        ClearCamera.enabled = false;

        //パネル非表示
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
            Debug.Log("ゴール");

            SoundPlayer.StopBGM();
            SoundPlayer.GetSoundManagaer().StopAllSe();

            GoalPanel.SetActive(true);

            //プレイヤーのゴールアニメーション
            playercontroller player = other.GetComponent<playercontroller>();
            player.animator.SetBool("IsGoal", true);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1.0f);

            TimeManager.state = TimeManager.TimeState.TIME_PAUSE;

            //ゴールUIのアニメーション
            anim.SetBool("Goal", true);

            //カメラの切り替え
            ClearCamera.enabled = true;
            MainCamera.enabled = false;

            //ステージセレクトの色付け
            ColorFlag[(int)ThisStageNum] = true;
            Debug.Log(ThisStageNum + "は" + ColorFlag[(int)ThisStageNum]);
        }
        else
        {
            Debug.Log("other");
        }
    }
}
