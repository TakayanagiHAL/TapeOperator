using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWork : MonoBehaviour
{
    [SerializeField] SwitchWork switch_obj;

    private Transform door;

    // Start is called before the first frame update
    void Start()
    {
        door = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (switch_obj.is_enter)
        {
            door.gameObject.SetActive(false);
        }
        else
        {
            door.gameObject.SetActive(true);
        }
    }
}
