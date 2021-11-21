using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingManager : MonoBehaviour
{
    private AudioPlayer audioplayer;
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GameObject.FindObjectOfType<AudioPlayer>();
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
                    Debug.Log(2222);
                    PlayMusic("d");
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

    void PlayMusic(string name)
    {
        if (audioplayer != null) audioplayer.GetComponent<AudioPlayer>().playMusic(name);
    }
    void PlaySFX(string name)
    {
        if (audioplayer != null) audioplayer.GetComponent<AudioPlayer>().playSFX(name);
    }
}