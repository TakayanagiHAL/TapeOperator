using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] GameObject StageSelectPos;
    [SerializeField] GameObject TitlePos;
    [SerializeField] float ZoomTime;

    public static bool ZoomOutFlag;     //ズームアウトのフラグ
    private bool ZoomInFlag;            //ズームインのフラグ
    private Vector3 Velocity;           //現在の移動速度
    private float xVelocity;            //現在の回転速度
    private GameObject Album;           //Albumを取得する変数

    // Start is called before the first frame update
    void Start()
    {
        ZoomInFlag = false;
        ZoomOutFlag = false;
        Album = GameObject.Find("Photoalbum");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Select") && transform.position.x == TitlePos.transform.position.x)
        {
            Album.GetComponent<Animator>().SetBool("OpenFlag", true);
            transform.position = TitlePos.transform.position;
            transform.eulerAngles = TitlePos.transform.eulerAngles;
            ZoomInFlag = true;
        }

        //ズームイン処理
        if (ZoomInFlag == true)
        {
            //位置を徐々に移動
            transform.position = Vector3.SmoothDamp(transform.position, StageSelectPos.transform.position, ref Velocity, ZoomTime);

            //ちょっとズームしたら回転を始める
            if(transform.position.y <= StageSelectPos.transform.position.y + 0.9f)
            {
                //角度を徐々に回転
                var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, StageSelectPos.transform.eulerAngles.x, ref xVelocity, ZoomTime);
                transform.eulerAngles = new Vector3(xRotate, 0.0f, 0.0f);
            }

            //一定距離近付いたらズームを止める
            if (transform.position.y <= StageSelectPos.transform.position.y + 0.001f)  
            {
                Debug.Log("ズーム終わり");

                transform.position = StageSelectPos.transform.position;
                transform.eulerAngles = StageSelectPos.transform.eulerAngles;

                ZoomInFlag = false;
            }
        }
        else if (ZoomOutFlag == true)
        {
            //位置を徐々に移動
            transform.position = Vector3.SmoothDamp(transform.position, TitlePos.transform.position, ref Velocity, ZoomTime);

            //角度を徐々に回転
            var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, TitlePos.transform.eulerAngles.x, ref xVelocity, ZoomTime - 0.5f);
            transform.eulerAngles = new Vector3(xRotate, 0.0f, 0.0f);


            //一定距離近付いたらズームを止める
            if (transform.position.y >= TitlePos.transform.position.y - 0.001f)
            {
                Debug.Log("ズーム終わり");

                transform.position = TitlePos.transform.position;
                transform.eulerAngles = TitlePos.transform.eulerAngles;
                ZoomOutFlag = false;
            }
        }
    }

    public void ZoomOutStart()
    {
        transform.eulerAngles = StageSelectPos.transform.eulerAngles;
        transform.position = StageSelectPos.transform.position;
        ZoomOutFlag = true;
    }

    public void SetTitlePos()
    {
        transform.position = TitlePos.transform.position;
    }

    public void SetStageSelectPos()
    {
        transform.position = StageSelectPos.transform.position;
    }
}
