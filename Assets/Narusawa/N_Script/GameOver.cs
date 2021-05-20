using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject SceneChanger;           //ScheneChangerがついたオブジェクトを取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryGame()
    {
        //次のシーンを読み込む
        ScheneChanger.ChangeScene(ZoomPhoto.StageNum);
    }
}
