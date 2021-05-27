using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSelect : MonoBehaviour
{
    [SerializeField] GameObject[] Photos;       //各ステージの写真を入れる配列
    [SerializeField] Vector3 SelectScale;       //選んでいる写真の拡大
    [SerializeField] Color TextSelectColor;         //テキストの選択時のカラー
    public static int SelectNum;                //選んでいる選択肢の番号
    public static int PhotoMax;                 //1ページの写真数
    private Vector3[] InitScale;                //スケールの初期値
    private bool JoyInput = false;              //ジョイスティックの入力受け付け

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        SelectNum = 1;
        JoyInput = false;

        //選択肢の最大数を求める
        PhotoMax = Photos.Length;

        //メモリ確保
        InitScale = new Vector3[Photos.Length];

        for (int i = 0; i < Photos.Length; i++)
        {
            //シーン切り替えのスクリプトをいったんオフにする
            Photos[i].GetComponent<ZoomPhoto>().enabled = false;

            //初期値の設定
            InitScale[i] += Photos[i].transform.localScale;
        }

        //最初に選んでいる選択肢を少し大きくする
        Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x, 
                                                             InitScale[SelectNum].y * SelectScale.y, 
                                                             InitScale[SelectNum].z * SelectScale.z);

        //最初に選んでいる選択肢のシーン切り替えスクリプトをオンにする
        Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            JoyInput = false;
        }

        //入力を受け取る
        if (Input.GetKeyDown(KeyCode.D) || JoyInput == false && Input.GetAxisRaw("Horizontal") == 1) 
        {
            JoyInput = true;    //入力されている

            //正の入力で選択肢数を超えていない場合次の選択肢へ
            if (SelectNum < Photos.Length - 1)
            {
                //最初の選択肢のテキストから次の選択肢に行く場合、テキストの色を黒にする
                if (SelectNum == 0)
                {
                    Photos[SelectNum].GetComponent<Renderer>().material.color = Color.black;
                }

                //サイズを初期値に戻す
                Photos[SelectNum].transform.localScale = InitScale[SelectNum];

                //選んでいる選択肢のシーン切り替えスクリプトをオフにする
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = false;

                //次の選択肢へ
                SelectNum++;

                //選んでいる写真を少し大きくする
                Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x,
                                                                     InitScale[SelectNum].y * SelectScale.y,
                                                                     InitScale[SelectNum].z * SelectScale.z);

                //選んでいる選択肢のシーン切り替えスクリプトをオンにする
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;

                //一番最後の選択肢だったら文字色を変更する
                if(SelectNum== Photos.Length - 1)
                {
                    Photos[SelectNum].GetComponent<Renderer>().material.color = TextSelectColor;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || JoyInput == false && Input.GetAxisRaw("Horizontal") == -1)
        {
            JoyInput = true;    //入力されている

            //負の入力で0より大きい場合前の選択肢へ
            if (SelectNum >0)
            {
                //最後の選択肢のテキストから前の選択肢に行く場合、テキストの色を黒にする
                if (SelectNum == Photos.Length - 1)
                {
                    Photos[SelectNum].GetComponent<Renderer>().material.color = Color.black;
                }

                //サイズを初期値に戻す
                Photos[SelectNum].transform.localScale = InitScale[SelectNum];

                //選んでいる選択肢のシーン切り替えスクリプトをオフにする
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = false;

                //前の選択肢へ
                SelectNum--;

                //選んでいる写真を少し大きくする
                Photos[SelectNum].transform.localScale = new Vector3(InitScale[SelectNum].x * SelectScale.x,
                                                                     InitScale[SelectNum].y * SelectScale.y,
                                                                     InitScale[SelectNum].z * SelectScale.z);

                //選んでいる選択肢のシーン切り替えスクリプトをオンにする
                Photos[SelectNum].GetComponent<ZoomPhoto>().enabled = true;

                //一番最初の選択肢だったら文字色を変更する
                if (SelectNum == 0)
                {
                    Photos[SelectNum].GetComponent<Renderer>().material.color = TextSelectColor;
                }
            }
        }
    }

    public void ResetScale()
    {
        //スケールのリセット
        Photos[SelectNum].transform.localScale = InitScale[SelectNum];

        for (int i = 0; i < Photos.Length; i++)
        {
            //シーン切り替えのスクリプトをいったんオフにする
            Photos[i].GetComponent<ZoomPhoto>().enabled = false;
        }

        //最初に選んでいる選択肢を少し大きくする
        Photos[1].transform.localScale = new Vector3(InitScale[1].x * SelectScale.x,
                                                     InitScale[1].y * SelectScale.y,
                                                     InitScale[1].z * SelectScale.z);

        //最初に選んでいる選択肢のシーン切り替えスクリプトをオンにする
        Photos[1].GetComponent<ZoomPhoto>().enabled = true;
    }
}
