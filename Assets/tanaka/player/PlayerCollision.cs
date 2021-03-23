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

    //指定の物と当たっている間
    void OnCollisionStay(Collision other)
    {
        //蔦と当たっているとき
        if (other.gameObject.tag == "ivy")
        {
            //Wキーが押されていたら
            if (Input.GetKey(KeyCode.W))
            {
                //蔦で上がる最大値より低い間上昇させる
                if (transform.position.y < IvyUpMaxPos)
                {
                    transform.position += new Vector3(0, IvyUpSpeed, 0);
                }
            }

        }
    }


    //指定の物に当たった時の判定
    void OnCollisionEnter(Collision other)
    {
        //ゴールと当たった時
        if (other.gameObject.tag == "goal")
        {
            Debug.Log("ゴール！！");
            SceneManager.LoadScene("GameClear");
        }

        //穴となる地面と当たった時
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
