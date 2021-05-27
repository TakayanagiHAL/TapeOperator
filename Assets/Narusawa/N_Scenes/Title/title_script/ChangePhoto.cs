using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhoto : MonoBehaviour
{
    [SerializeField] GameObject[] Photos;       //�e�X�e�[�W�̎ʐ^������z��
    [SerializeField] Material[] ClearMaterial;  //�N���A��̃}�e���A��

    // Start is called before the first frame update
    void Start()
    {
        //�N���A�ς݂̎ʐ^�̃}�e���A����ύX����
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
