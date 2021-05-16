using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmilFloorLHit : MonoBehaviour
{

    public static bool isHitL;

    GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        isHitL = false;
        parentGameObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isHitL);
    }


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(parentGameObject.transform);
        isHitL = true;
    }

    void OnTriggerStay(Collider other)
    {
        
        isHitL = true;

       
    }

    void OnTriggerExit(Collider other)
    {
        isHitL = false;
       
        other.gameObject.transform.SetParent(null);
        other.gameObject.transform.localScale = new Vector3(1, 2, 1);
    }
}
