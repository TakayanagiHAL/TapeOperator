using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject SceneChanger;           //ScheneChanger�������I�u�W�F�N�g���擾

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryGame()
    {
        //���̃V�[����ǂݍ���
        ScheneChanger.ChangeScene(ZoomPhoto.StageNum);
    }
}
