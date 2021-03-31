using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BridgeWork : MonoBehaviour
{

    //　カメラ内にいるかどうか
    private bool isInsideCamera;

    //一度壊れたか
    private bool isOneBreak;
    //元に戻ったか
    private bool isRepair;
    //表示、非表示判定
    private bool inVisible;
   
    [SerializeField]
    private List<Transform> targetPoints;

    protected BoxCollider boxCollider;

    protected List<Rigidbody> separateBlocks;

    public int FallTime;

    private int FallTimeBase;

    BackData[] pos_data;     //位置情報記録用

    Vector3[] start_pos;

    // Start is called before the first frame update
    void Start()
    {
        isInsideCamera =
            isRepair =
            inVisible =
            isOneBreak = false;

        FallTimeBase = FallTime;

        pos_data = new BackData[targetPoints.Count];
        start_pos = new Vector3[targetPoints.Count];
        for (int i = 0; i < targetPoints.Count; i++)
        {
            pos_data[i] = new BackData();
            pos_data[i].Init();
        }
        //最初のポジションを格納しておく
        int i1 = 0;
        foreach (var targetPoint in targetPoints)
        {

            start_pos[i1] = targetPoint.position;
        }

            boxCollider = GetComponent<BoxCollider>();

        separateBlocks = GetComponentsInChildren<Rigidbody>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //壊れていないとき
        if (!isOneBreak)
        {
          
            //カメラに入っていないとき
            if (!isInsideCamera)
            {
                CameraInObject();
            }
            //カメラに入った時
            else
            {
                var min = -5;
                var max = 5;

                FallTime--;
                switch (TimeManager.state)
                {
                    case TimeManager.TimeState.TIME_BACK:
                        //壊れるのを終わりにする
                        isOneBreak = true;

                        //全ての子オブジェクトの物理判定をなくす
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = true;

                            var vect = new Vector3(0, 0, 0);
                            r.AddForce(vect, ForceMode.Impulse);
                        });
                        break;

                    case TimeManager.TimeState.TIME_FAST:
                        
                        var random = new System.Random();

                        //全ての子オブジェクトを動かす
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = false;

                            var vect = new Vector3(random.Next(min, max) / 10.0f, random.Next(min, max) / 10.0f, random.Next(min, max) / 10.0f);
                            r.AddForce(vect, ForceMode.Impulse);
                        });

                        //全ての子オブジェクトの座標データ保存
                        int cf = 0;
                        targetPoints.ForEach(t =>
                        {

                            pos_data[cf].AddData(t.position);
                            cf++;

                        });
                        

                        break;

                    case TimeManager.TimeState.TIME_PLAY:
           
                        var random1 = new System.Random();
                        //全ての子オブジェクトを動かす
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = false;

                            var vect = new Vector3(random1.Next(min, max) / 10.0f, random1.Next(min, max) / 10.0f, random1.Next(min, max) / 10.0f);
                            r.AddForce(vect, ForceMode.Impulse);
                        });


                        //全ての子オブジェクトの座標データ保存
                        int cp = 0;
                        targetPoints.ForEach(t =>
                        {

                            pos_data[cp].AddData(t.position);
                            cp++;

                        });

                        break;

                    case TimeManager.TimeState.TIME_STOP:
                        break;
                }
                if(FallTime < 0)
                {
                    //非表示にする
                    targetPoints.ForEach(t =>
                    {
                        t.gameObject.SetActive(false);
                    });

                    //物理判定をなくす
                    separateBlocks.ForEach(r =>
                    {
                        r.isKinematic = true;

                        var vect = new Vector3(0, 0, 0);
                        r.AddForce(vect, ForceMode.Impulse);
                    });

                    isOneBreak = true;
                    inVisible = true;
                    FallTime = FallTimeBase;
                }

            }
        }
        //壊れたとき
        else
        {
            //直るまで
            if(!isRepair)
            {
                switch (TimeManager.state)
                {
                    case TimeManager.TimeState.TIME_BACK:
                        //見えるようにする
                        if(inVisible)
                        {
                            inVisible = false;
                            targetPoints.ForEach(t =>
                            {
                                t.gameObject.SetActive(true);
                            });

                        }
                        //元に戻す
                        int cb = 0;
                        targetPoints.ForEach(t =>
                        {
                            t.position = pos_data[cb].DataBack();
                            cb++;
                        });

                        
                        int i2 = 0;
                        foreach (var targetPoint in targetPoints)
                        {
                            //元に戻った
                            if (start_pos[i2] == targetPoint.position)
                            {
                                isRepair = true;
                                boxCollider.enabled = true;
                            }
                            
                        }


                        break;

                    case TimeManager.TimeState.TIME_FAST:

                        break;

                    case TimeManager.TimeState.TIME_PLAY:

                        break;

                    case TimeManager.TimeState.TIME_STOP:
                        break;
                }
            }
           
        }

        

    }
    //カメラ内にいるかいないか判定する
    private void CameraInObject()
    {
        int count = 0;

        //　カメラのビューポート位置
        Vector2 viewportPoint;

        //　ターゲットポイントがカメラのビューポート内にあるかどうかを調べる
        foreach (var targetPoint in targetPoints)
        {
            //　ビューポートの計算
            viewportPoint = Camera.main.WorldToViewportPoint(targetPoint.position);

            if (0f <= viewportPoint.x && viewportPoint.x <= 1f
                && 0f <= viewportPoint.y && viewportPoint.y <= 1f
                )
            {
                count++;              
            }
            else
            { 
                break;
            }
        }

        if (count == targetPoints.Count)
        {

            isInsideCamera = true;
            boxCollider.enabled = false;

        }


    }

}
