using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] Canvas;   //�e�y�[�W��Canvas������z��
    public static int PageNum = 0;          //���̃y�[�W����\���ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�S����Canvas��false�ɂ���
        for(int i = 0; i < Canvas.Length; i++)
        {
            Canvas[i].SetActive(false);
        }
        Canvas[PageNum].SetActive(true);    //���̃y�[�W��Canvas��true�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //�O�̃y�[�WUI���ĂԊ֐�
    public void BeforePageCall()
    {
        //�y�[�W����0���傫���ꍇ
        if (PageNum > 0)
        {
            Canvas[PageNum].SetActive(false);   //���̃y�[�W��Canvas��false�ɂ���
            PageNum--;                          //�y�[�W�����P���炷  
            Canvas[PageNum].SetActive(true);    //���炵����̃y�[�W��Canvas��true�ɂ���
        }
    }


    //���̃y�[�WUI���ĂԊ֐�
    public void NextPageCall()
    {
        if (PageNum < Canvas.Length)
        {
            Canvas[PageNum].SetActive(false);   //���̃y�[�W��Canvas��false�ɂ���
            PageNum++;                          //�y�[�W�����P���₷  
            Canvas[PageNum].SetActive(true);    //���₵����̃y�[�W��Canvas��true�ɂ���
        }
    }
}
