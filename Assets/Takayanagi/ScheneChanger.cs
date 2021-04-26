using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScheneChanger : MonoBehaviour
{
    [SerializeField] KeyCode key;
    [SerializeField] SCENE_NAME scene;
    public enum SCENE_NAME
    {
        BETA1,
        BETA2,
        BETA3,
        BETA4,
        BETA5,
        SCENE_MAX
    }

    private string[] scene_name = new string[] {
        "Takayanagi/be-ta/be-ta1",
        "Takayanagi/be-ta/be-ta2",
        "Takayanagi/be-ta/be-ta3",
        "Takayanagi/be-ta/be-ta4",
        "Takayanagi/be-ta/be-ta5"
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            SceneManager.LoadScene(scene_name[(int)scene]);
        }
    }

    public void ChangeScene(SCENE_NAME scene)
    {
        SceneManager.LoadScene(scene_name[(int)scene]);
    }
  
}
