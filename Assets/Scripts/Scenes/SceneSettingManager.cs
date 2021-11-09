using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        prepareSceneSettings();
    }

    // Update is called once per frame
    private void prepareSceneSettings()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneLoader.Scene scene = SceneLoader.getSceneByName(sceneName);

        switch (scene)
        {
            case SceneLoader.Scene.THE_NEIGHBOURHOOD:
                {
                    // Init settings for the neighbourhood scene
                    break;
                }
            case SceneLoader.Scene.THE_SCRAPYARD:
                {
                    // Init settings for the scrapyard scene
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
