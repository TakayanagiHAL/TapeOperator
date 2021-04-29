using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject targetObj;    //�ǂ��^�[�Q�b�g�̃I�u�W�F�N�g���󂯎��ϐ�
    Vector3 TargetPos;              //�^�[�Q�b�g�̃|�W�V�����ێ��p�̕ϐ�

    void Start()
    {
        //�v���C���[�̃|�W�V�����ێ�
        TargetPos = targetObj.transform.position;
    }

    void Update()
    {
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - TargetPos;
        TargetPos = targetObj.transform.position;

    }
}
