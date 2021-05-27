using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] GameObject StageSelectPos;
    [SerializeField] GameObject TitlePos;
    [SerializeField] float ZoomTime;

    public static bool ZoomOutFlag;     //�Y�[���A�E�g�̃t���O
    private bool ZoomInFlag;            //�Y�[���C���̃t���O
    private Vector3 Velocity;           //���݂̈ړ����x
    private float xVelocity;            //���݂̉�]���x
    private GameObject Album;           //Album���擾����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        ZoomInFlag = false;
        ZoomOutFlag = false;
        Album = GameObject.Find("Photoalbum");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Select") && transform.position.x == TitlePos.transform.position.x)
        {
            Album.GetComponent<Animator>().SetBool("OpenFlag", true);
            transform.position = TitlePos.transform.position;
            transform.eulerAngles = TitlePos.transform.eulerAngles;
            ZoomInFlag = true;
        }

        //�Y�[���C������
        if (ZoomInFlag == true)
        {
            //�ʒu�����X�Ɉړ�
            transform.position = Vector3.SmoothDamp(transform.position, StageSelectPos.transform.position, ref Velocity, ZoomTime);

            //������ƃY�[���������]���n�߂�
            if(transform.position.y <= StageSelectPos.transform.position.y + 0.9f)
            {
                //�p�x�����X�ɉ�]
                var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, StageSelectPos.transform.eulerAngles.x, ref xVelocity, ZoomTime);
                transform.eulerAngles = new Vector3(xRotate, 0.0f, 0.0f);
            }

            //��苗���ߕt������Y�[�����~�߂�
            if (transform.position.y <= StageSelectPos.transform.position.y + 0.001f)  
            {
                Debug.Log("�Y�[���I���");

                transform.position = StageSelectPos.transform.position;
                transform.eulerAngles = StageSelectPos.transform.eulerAngles;

                ZoomInFlag = false;
            }
        }
        else if (ZoomOutFlag == true)
        {
            //�ʒu�����X�Ɉړ�
            transform.position = Vector3.SmoothDamp(transform.position, TitlePos.transform.position, ref Velocity, ZoomTime);

            //�p�x�����X�ɉ�]
            var xRotate = Mathf.SmoothDampAngle(transform.eulerAngles.x, TitlePos.transform.eulerAngles.x, ref xVelocity, ZoomTime - 0.5f);
            transform.eulerAngles = new Vector3(xRotate, 0.0f, 0.0f);


            //��苗���ߕt������Y�[�����~�߂�
            if (transform.position.y >= TitlePos.transform.position.y - 0.001f)
            {
                Debug.Log("�Y�[���I���");

                transform.position = TitlePos.transform.position;
                transform.eulerAngles = TitlePos.transform.eulerAngles;
                ZoomOutFlag = false;
            }
        }
    }

    public void ZoomOutStart()
    {
        transform.eulerAngles = StageSelectPos.transform.eulerAngles;
        transform.position = StageSelectPos.transform.position;
        ZoomOutFlag = true;
    }

    public void SetTitlePos()
    {
        transform.position = TitlePos.transform.position;
    }

    public void SetStageSelectPos()
    {
        transform.position = StageSelectPos.transform.position;
    }
}
