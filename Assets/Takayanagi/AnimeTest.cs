using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeTest : MonoBehaviour
{
    // Start is called before the first frame update

    int test;

    public Animator animator;
    void Start()
    {
        test = animator.GetInteger("TestState");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(test);
            test++;
            test %= 3;
            animator.SetInteger("TestState", test);

        }
    }
}
