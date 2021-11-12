using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        prepareSceneSettings();
    }

    /**
     * Prepares all settings needed for this scene
     */
    void prepareSceneSettings()
    {
        prepareGlobalSceneSettings();
        prepareCurrentSceneSettings();
    }

    /**
     * This wil prepare the settings used in all scenes
     */
    void prepareGlobalSceneSettings()
    {
        // TODO if any
    }

    /**
     * This will prepare the settings for the current scene only
     */
    void prepareCurrentSceneSettings()
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