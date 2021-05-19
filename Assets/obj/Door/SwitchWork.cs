using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWork : MonoBehaviour
{
    public bool is_enter;
    private Animator animator;
    private bool is_on;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_enter)
        {
            if (!is_on)
            {
                animator.SetFloat("speed", 1);
                animator.Play("button", 0, 0.0f);
                is_on = true;
            }
        }
        else
        {
            if (is_on)
            {
                animator.SetFloat("speed", -1);
                animator.Play("button", 0, 1.0f/60.0f*15.0f);
                is_on = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        is_enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        is_enter = false;
    }
}
