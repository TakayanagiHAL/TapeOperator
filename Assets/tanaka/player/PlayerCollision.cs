using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float IvyUpMaxPos = 15.0f;
    public float IvyUpSpeed = 0.45f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�w��̕��Ɠ������Ă����
    void OnCollisionStay(Collision other)
    {
        //�ӂƓ������Ă���Ƃ�
        if (other.gameObject.tag == "ivy")
        {
            //W�L�[��������Ă�����
            if (Input.GetKey(KeyCode.W))
            {
                //�ӂŏオ��ő�l���Ⴂ�ԏ㏸������
                if (transform.position.y < IvyUpMaxPos)
                {
                    transform.position += new Vector3(0, IvyUpSpeed, 0);
                }
            }

        }
    }


    //�w��̕��ɓ����������̔���
    void OnCollisionEnter(Collision other)
    {
        //�S�[���Ɠ���������
        if (other.gameObject.tag == "goal")
        {
            Debug.Log("�S�[���I�I");
            SceneManager.LoadScene("GameClear");
        }

        //���ƂȂ�n�ʂƓ���������
        if (other.gameObject.tag == "hole")
        {
            Debug.Log("GameOver!!");
            SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
