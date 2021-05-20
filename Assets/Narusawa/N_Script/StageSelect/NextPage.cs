using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    //PageChangerのついたオブジェクトを取得
    [SerializeField] GameObject PageChanger;
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelectのついたオブジェクトを取得


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一番最後を選択している場合
        if (PhotoSelect.SelectNum == PhotoSelect.PhotoMax - 1 && Input.GetButtonDown("Select")) 
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //次のページを表示
            PageChanger.GetComponent<PageChanger>().NextPageCall();
        }
    }
}
