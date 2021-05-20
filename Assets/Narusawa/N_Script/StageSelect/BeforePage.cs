using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePage : MonoBehaviour
{
    [SerializeField] GameObject PageChanger;        //PageChangerのついたオブジェクトを取得
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelectのついたオブジェクトを取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一番最初を選択している場合
        if (PhotoSelect.SelectNum == 0 && Input.GetButtonDown("Select"))
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //前のページを表示
            PageChanger.GetComponent<PageChanger>().BeforePageCall();
        }

    }
}
