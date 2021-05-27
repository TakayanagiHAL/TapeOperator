using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] Pages;   //�e�y�[�W��CGameObject������z��
    public static int PageNum = 0;         //���̃y�[�W����\���ϐ�
    private Animator anim;                 //Animator�擾�p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //������
        PageNum = 0;

        //�S����Canvas��false�ɂ���
        for(int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }

        //�A���o����Animator�R���|�[�l���g��ݒ�
        anim = this.GetComponent<Animator>();

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
            Pages[PageNum].SetActive(false);       //���̃y�[�W��GameObject��false�ɂ���
            PageNum--;                              //�y�[�W�����P���炷  
            anim.SetBool("BeforePageFlag", true);  //�O�̃y�[�W�̃A�j���[�V������true�ɂ���
        }
    }


    //���̃y�[�WUI���ĂԊ֐�
    public void NextPageCall()
    {
        if (PageNum < Pages.Length - 1) 
        {
            Pages[PageNum].SetActive(false);   //���̃y�[�W��GameObject��false�ɂ���
            PageNum++;                          //�y�[�W�����P���₷  
            anim.SetBool("NextPageFlag", true);    //���̃y�[�W�̃A�j���[�V������true�ɂ���
        }
    }

    public void CanvasDisp()
    {
        Pages[PageNum].SetActive(true);    //�w��y�[�W��GameObject��true�ɂ���
    }

    //�{�����
    public void CloseBook()
    {
        Pages[PageNum].SetActive(false);   //���̃y�[�W��GameObject��false�ɂ���
        anim.SetBool("CloseFlag", true);
        anim.SetBool("OpenFlag", false);
    }
}
