using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHit : MonoBehaviour
{
    [SerializeField] ScheneChanger.SCENE_NAME scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ScheneChanger.ChangeScene((int)scene);
        }
    }
}
