using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecleCreater : MonoBehaviour
{
    [SerializeField] GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.gameObject.SetActive(false);
        Debug.Log("Create");
        Instantiate(obj,transform.position,transform.localRotation);

    }

    public void CreateIce()
    {

    }
}
