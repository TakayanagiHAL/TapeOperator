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
        GAME_OVER,
        EGYPT_1,
        EGYPT_2,
        EGYPT_3,
        RUSSIA_1,
        SCENE_MAX
    }

    private static string[] scene_name = new string[] {
        "Narusawa/N_scenes/StageSelect",
        "Narusawa/N_scenes/GameOver",
        "Scenes/Egypt/1-1/Egypt_Sunny_Sample",
        "Scenes/Egypt/1-2/Egypt_1_2",
        "Scenes/Egypt/1-3/Egypt_1_3",
        "Scenes/Russia/Russia_1_1"
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
