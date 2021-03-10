using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerVer2 : MonoBehaviour
{
    [SerializeField]
    PlayerParameter playerParameter;
    private Vector3 baseAngle;   //�����p�x
    private float jumpPower = 0.0f;
    private bool isJumpRise = false;    //�㏸���W�����v�t���O
    private float jumpTimeCounter;  //�W�����v�J�E���g
    private bool isGround = false;   //�n�ʃt���O
    private float Direction = 0.0f; //����
    private Rigidbody rb;
    private LayerMask layerMask;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        baseAngle = transform.eulerAngles;

        rb.constraints =
        RigidbodyConstraints.FreezeRotationX |
        RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // �J�[�\���L�[�̓��͂��擾
        //�E�ړ�
        if (Input.GetKey(KeyCode.D))
        {
            Direction = 1.0f;

        }
        //���ړ�
        else if (Input.GetKey(KeyCode.A))
        {
            Direction = -1.0f;
        }
        //�����ĂȂ��Ƃ�
        else
        {
            Direction = 0.0f;
        }

        //������ς���
        if (Direction > 0.0f)
        {
            //�E����
            transform.eulerAngles = baseAngle;
        }
        else if (Direction < 0.0f)
        {
            //������
            transform.eulerAngles = new Vector3(0.0f, baseAngle.y + 180.0f, 0.0f);
        }

        //�n�ʂɂ���Ƃ�
        if (isGround)
        {
            //�W�����v
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpTimeCounter = playerParameter.JumpTime;
                isJumpRise = true;
                isGround = false;
                jumpPower = playerParameter.BaseJumpPower;
            }

            //���ړ�
            rb.velocity = new Vector3(Direction * playerParameter.MoveSpeed , rb.velocity.y, 0.0f);

        }
        //�n�ʂɂ��Ȃ�
        else
        {
            //���~��
            if (!isJumpRise)
            {
                //�d�͂̒l�ݒ�
                rb.velocity = new Vector3(rb.velocity.x, Physics.gravity.y * playerParameter.GravityPower, 0.0f);
            }
            //�󒆎��̉��ړ�
            rb.velocity = new Vector3(Direction * playerParameter.JumpMoveSpeed, rb.velocity.y, 0.0f);
        }
        //�����Ă�ԏ㏸
        if (Input.GetKey(KeyCode.Space) && isJumpRise)
        {
            //�㏸���ԓ�
            if (jumpTimeCounter > 0)
            {
                //�㏸
                rb.velocity = new Vector3(rb.velocity.x, 1.0f * jumpPower, 0.0f);
                jumpTimeCounter -= Time.deltaTime;
            }
            //�㏸���ԊO
            else
            {
                isJumpRise = false;
            }
        }
        //�������ꍇ�㏸�𒆎~
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumpRise = false;

        }

    }


    //��������
    private void OnCollisionEnter(Collision collision)
    {

        if (1 << collision.gameObject.layer != layerMask)
        {
            //�^��
            if (Physics.Linecast(transform.position + Vector3.down * 0.8f, transform.position + Vector3.down * 1.2f))
            {
                isGround = true;
                return;
            }
            //�n�_
            var start = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.4f, 0.0f);
            //�I�_
            var end = new Vector3(start.x, start.y - 0.8f, 0.0f);
            //�E
            if (Physics.Linecast(start, end))
            {
                isGround = true;
                return;
            }
            //�n�_
            start = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.4f, 0.0f);
            //�I�_
            end = new Vector3(start.x, start.y - 0.8f, 0.0f);
            //��
            if (Physics.Linecast(start, end))
            {
                isGround = true;
                return;
            }
        }

    }
    //�����Ă����
    private void OnCollisionStay(Collision collision)
    {
        //�v���C���[���C���ȊO
        if (1 << collision.gameObject.layer != layerMask)
        {//�㏸���̎�
            if (isJumpRise)
            {
                //�^��
                if (Physics.Linecast(transform.position + Vector3.down * 0.8f, transform.position + Vector3.down * 1.2f))
                {
                    isGround = true;
                    //Debug.Log("�^��");
                    return;
                }
                var start = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.4f, 0.0f);
                var end = new Vector3(start.x, start.y - 0.8f, 0.0f);
                //�E
                if (Physics.Linecast(start, end))
                {
                    isGround = true;
                    return;
                }
                start = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.4f, 0.0f);
                end = new Vector3(start.x, start.y - 0.8f, 0.0f);
                //��
                if (Physics.Linecast(start, end))
                {
                    isGround = true;
                    return;
                }
            }
        }
    }
    //�o���Ƃ�
    private void OnCollisionExit(Collision collision)
    {
        //�@�n�ʂ���~�肽���̏���
        //�@Field���C���[�̃Q�[���I�u�W�F�N�g���痣�ꂽ��
        if (1 << collision.gameObject.layer != layerMask)
        {
            //�������Ƀ��C���[���΂�Field���C���[�ƐڐG���Ȃ���Βn�ʂ��痣�ꂽ�Ɣ��肷��
            if (!Physics.Linecast(transform.position + Vector3.down * 0.8f, transform.position + Vector3.down * 1.1f))
            {
                isGround = false;
            }

        }
    }

}
