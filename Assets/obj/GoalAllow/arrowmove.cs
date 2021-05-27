using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmove : MonoBehaviour
{

    [SerializeField] int period = 90;
    private int frame = 0;
    private bool flag = false;

    [SerializeField] float changevalue = 0.02f;
    private float InToNum = 0.0f;

    private Vector3 startpos;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
        flag = false;
        InToNum = 0.0f;
        startpos = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        frame++;

        if (frame % period == 0)
        {
            if(flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
        }

        if (flag)
        {
            InToNum += Mathf.Sin(Mathf.Deg2Rad * (360 / (frame % period + 1))) * changevalue;
        }
        else
        {
            InToNum -= Mathf.Sin(Mathf.Deg2Rad * (360 / (frame % period + 1))) * changevalue;
        }

        transform.position = new Vector3(startpos.x, startpos.y + InToNum, startpos.z);

        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));

        //rb.AddForce(new Vector3(0, InToNum, 0));

        Debug.Log(InToNum);

    }
}
