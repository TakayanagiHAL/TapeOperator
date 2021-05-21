using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WaterRippleForScreens;

public class ZoomPhoto : MonoBehaviour
{
    //ズーム関連
    [SerializeField] bool Zoom_Flag = true;             //ズームするかのフラグ
    [SerializeField] GameObject MainCam;                //ズームするカメラ
    [SerializeField] float TargetDistance = 0.3f;       //選択された写真との距離
    [SerializeField] float ZoomTime = 1.0f;             //ズームにかける時間
    [SerializeField] GameObject SceneChanger;           //ScheneChangerがついたオブジェクトを取得
    [SerializeField] GameObject PhotoSelect_obj;        //PhotoSelectのついたオブジェクトを取得
    [SerializeField] ScheneChanger.SCENE_NAME scene;    //読み込むシーン
    [SerializeField] Fade fade;
    private bool ZoomStart_Flag = false;    //ズームを始めるフラグ
    private Vector3 Target;                 //選択された写真の位置＋Distance
    private Transform CamTns;               //カメラのtransform取得用
    private Vector3 velocity;               //ズームする現在の速度

    //波紋関連
    [SerializeField] float WaveTime = 3;        //波紋をさせる時間
    [SerializeField] float MaxWaveScale = 60;

    //ステージ番号を渡す
    public static int StageNum;

    // Start is called before the first frame update
    void Start()
    {
        //トランスフォームを取得
        CamTns = MainCam.transform;

        //ターゲットの設定
        Target = this.transform.position;
        Target.y += TargetDistance;

        ZoomStart_Flag = false;

    }

    // Update is called once per frame
    void Update()
    {
        //ズームをする
        if (Input.GetButtonDown("Select"))
        {
            SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Decision");
            ZoomStart_Flag = true;
            fade.StartFade();
        }

        if (ZoomStart_Flag == true)
        {
            if (Zoom_Flag == true)
            {
                CamTns.position = Vector3.SmoothDamp(CamTns.position, Target, ref velocity, ZoomTime);

                if (CamTns.position.y <= Target.y + 0.03f)
                {
                    Debug.Log("ズーム終わり");

                    //波紋の表示
                    Vector2 CamTarget = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                    MainCam.GetComponent<RippleEffect>().SetNewRipplePosition(CamTarget);

                    Invoke("SceneLoad", WaveTime);
                }
                if (Fade.FadeFinish)
                {
                    SoundPlayer.StopBGM();
                    //次のシーンを読み込む
                    StageNum = (int)scene;
                    ScheneChanger.ChangeScene(StageNum);
                    Fade.FadeFinish = false;
                    ZoomStart_Flag = false;
                }
            }
            else
            {
                if (Fade.FadeFinish)
                {
                    //次のシーンを読み込む
                    StageNum = (int)scene;
                    ScheneChanger.ChangeScene(StageNum);
                    Fade.FadeFinish = false;
                    ZoomStart_Flag = false;
                }
            }
        }
        
    }

    void SceneLoad()
    {
        //次のシーンを読み込む
        StageNum = (int)scene;
       // ScheneChanger.ChangeScene((int)scene);
    }
}
