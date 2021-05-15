using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalWork : MonoBehaviour
{
    [SerializeField] ScheneChanger.SCENE_NAME next_scene;

    private ScheneChanger scheneChanger;

    // Start is called before the first frame update
    void Start()
    {
        scheneChanger = new ScheneChanger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScheneChanger.ChangeScene((int)next_scene);
        }
    }
}
