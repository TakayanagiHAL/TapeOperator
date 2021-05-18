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


    //�w��̕��ɓ����������̔���
     void OnTriggerEnter(Collider other)
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
