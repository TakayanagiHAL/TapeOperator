using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWork : MonoBehaviour
{
    [SerializeField] SwitchWork switch_obj;

    private Animator animator;

    private bool is_open;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switch_obj.is_enter)
        {
            if (!is_open)
            {
                animator.SetFloat("speed", 1);
                animator.Play("gate", 0, 0.0f);
                is_open = true;
            }
        }
        else
        {
            if (is_open)
            {
                animator.SetFloat("speed", -1);
                animator.Play("gate", 0, 1.0f/60.0f*80.0f);
                is_open = false;
            }
        }
    }
}
