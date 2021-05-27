using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhoto : MonoBehaviour
{
    [SerializeField] GameObject[] Photos;       //各ステージの写真を入れる配列
    [SerializeField] Material[] ClearMaterial;  //クリア後のマテリアル

    // Start is called before the first frame update
    void Start()
    {
        //クリア済みの写真のマテリアルを変更する
        if (ClearMaterial.Length != 0)
        {
            for (int i = 0; i < Photos.Length; i++)
            {
                if (Goal.ColorFlag[i] == true)
                {
                    Photos[i].GetComponent<Renderer>().material = ClearMaterial[i];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
