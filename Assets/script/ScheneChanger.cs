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
        STAGE_SELECT,
        BETA1,
        BETA2,
        BETA3,
        BETA4,
        BETA5,
        EGYPT_1,
        EGYPT_2,
        EGYPT_3,
        EGYPT_4,
        EGYPT_5,
        SCENE_MAX
    }

    private static string[] scene_name = new string[] {
        "Scenes/StageSelect/StageSelect",
        "Takayanagi/be-ta/be-ta1",
        "Takayanagi/be-ta/be-ta2",
        "Takayanagi/be-ta/be-ta3",
        "Takayanagi/be-ta/be-ta4",
        "Takayanagi/be-ta/be-ta5",
        "Scenes/Egypt/Egypt1_1/Egypt1_1",
        "Scenes/Egypt/Egypt1_2/Egypt1_2",
        "Scenes/Egypt/Egypt1_3/Egypt1_3",
        "Scenes/Egypt/Egypt1_4/Egypt1_4",
        "Scenes/Egypt/Egypt1_5/Egypt1_5",
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

   // [EnumAction(typeof(ScheneChanger.SCENE_NAME))]
   static public void ChangeScene(int name)
    {
        SceneManager.LoadScene(scene_name[(int)name]);
    }
  
}
