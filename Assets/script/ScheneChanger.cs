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
        EGYPT_1,
        EGYPT_2,
        EGYPT_3,
        EGYPT_4,
        EGYPT_5,
        RUSSIA_1,
        RUSSIA_2,
        RUSSIA_3,
        AFRICA_1,
        AFRICA_2,
        AFRICA_3,
        ANTARCTIC_1,
        ANTARCTIC_2,
        AUSTRALIA_1,
        AUSTRALIA_2,
        AUSTRALIA_3,
        NORWAY_1,
        NORWAY_2,
        NORWAY_3,
        SCENE_MAX
    }

    private static string[] scene_name = new string[] {
        "Narusawa/N_scenes/Title/Title",
        "Scenes/Egypt/1_1/Egypt_1_1",
        "Scenes/Egypt/1_2/Egypt_1_2",
        "Scenes/Egypt/1_3/Egypt_1_3",
        "Scenes/Egypt/1_4/Egypt_1_4",
        "Scenes/Egypt/1_5/Egypt_1_5",
        "Scenes/Russia/2_1/Russia_2_1",
        "Scenes/Russia/2_2/Russia_2_2",
        "Scenes/Russia/2_3/Russia_2_3",
        "Scenes/Africa/3_1/Africa_3_1",
        "Scenes/Africa/3_2/Africa_3_2",
        "Scenes/Africa/3_3/Africa_3_3",
        "Scenes/Antartic/4_1/Arctic_4_1",
        "Scenes/Antartic/4_2/Arctic_4_2",
        "Scenes/Australia/5_1/Australia_5_1",
        "Scenes/Australia/5_2/Australia_5_2",
        "Scenes/Australia/5_3/Australia_5_3",
        "Scenes/Norway/6_1/Norway_6_1",
        "Scenes/Norway/6_2/Norway_6_2",
        "Scenes/Norway/6_3/Norway_6_3"
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
        SoundPlayer.GetSoundManagaer().StopBgm();
        SoundPlayer.GetSoundManagaer().StopAllSe();
        SceneManager.LoadScene(scene_name[(int)name]);
    }

    static public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}
