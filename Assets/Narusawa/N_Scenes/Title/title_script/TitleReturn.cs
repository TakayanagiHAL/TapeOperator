using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleReturn : MonoBehaviour
{
    [SerializeField] GameObject PageChanger_obj;    //PageChangerのついたオブジェクトを取得
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelectのついたオブジェクトを取得
    [SerializeField] GameObject MainCamera_obj;     //ZoomCameraのついたオブジェクトを取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一番最初を選択している場合
        if (((PhotoSelect.SelectNum == 0 && PageChanger.PageNum == 0) || (PageChanger.PageNum == 6 && PhotoSelect.SelectNum == 1))&& Input.GetButtonDown("Select"))
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //本を閉じる処理
            PageChanger_obj.GetComponent<PageChanger>().CloseBook();

            //タイトルに戻る
            MainCamera_obj.GetComponent<ZoomCamera>().ZoomOutStart();
        }
    }
}
