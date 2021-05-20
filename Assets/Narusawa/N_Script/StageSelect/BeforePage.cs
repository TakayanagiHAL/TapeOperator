using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePage : MonoBehaviour
{
    [SerializeField] GameObject PageChanger;        //PageChanger�̂����I�u�W�F�N�g���擾
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelect�̂����I�u�W�F�N�g���擾

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ԍŏ���I�����Ă���ꍇ
        if (PhotoSelect.SelectNum == 0 && Input.GetButtonDown("Select"))
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //�O�̃y�[�W��\��
            PageChanger.GetComponent<PageChanger>().BeforePageCall();
        }

    }
}
