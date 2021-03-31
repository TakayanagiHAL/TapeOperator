using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmilFloorRHit : MonoBehaviour
{

    public static bool isHitR;
    GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        isHitR = false;
        parentGameObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(parentGameObject.transform);
        isHitR = true;
    }

    void OnTriggerStay(Collider other)
    {

        isHitR = true;


    }

    void OnTriggerExit(Collider other)
    {
        isHitR = false;

        other.gameObject.transform.SetParent(null);
        other.gameObject.transform.localScale = new Vector3(1, 2, 1);
    }
}
