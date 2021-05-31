using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleReturn : MonoBehaviour
{
    [SerializeField] GameObject PageChanger_obj;    //PageChanger�̂����I�u�W�F�N�g���擾
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelect�̂����I�u�W�F�N�g���擾
    [SerializeField] GameObject MainCamera_obj;     //ZoomCamera�̂����I�u�W�F�N�g���擾

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ԍŏ���I�����Ă���ꍇ
        if (((PhotoSelect.SelectNum == 0 && PageChanger.PageNum == 0) || (PageChanger.PageNum == 6 && PhotoSelect.SelectNum == 1))&& Input.GetButtonDown("Select"))
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //�{����鏈��
            PageChanger_obj.GetComponent<PageChanger>().CloseBook();

            //�^�C�g���ɖ߂�
            MainCamera_obj.GetComponent<ZoomCamera>().ZoomOutStart();
        }
    }
}
