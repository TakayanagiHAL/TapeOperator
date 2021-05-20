using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    //PageChanger�̂����I�u�W�F�N�g���擾
    [SerializeField] GameObject PageChanger;
    [SerializeField] GameObject PhotoSelect_obj;    //PhotoSelect�̂����I�u�W�F�N�g���擾


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ԍŌ��I�����Ă���ꍇ
        if (PhotoSelect.SelectNum == PhotoSelect.PhotoMax - 1 && Input.GetButtonDown("Select")) 
        {
            PhotoSelect_obj.GetComponent<PhotoSelect>().ResetScale();

            PhotoSelect.SelectNum = 1;

            //���̃y�[�W��\��
            PageChanger.GetComponent<PageChanger>().NextPageCall();
        }
    }
}
