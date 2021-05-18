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


    //指定の物に当たった時の判定
     void OnTriggerEnter(Collider other)
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
