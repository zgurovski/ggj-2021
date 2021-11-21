using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    // Holds the game settings object
    
    private GameSettings settings;

    void Awake()
    {
        // Load settings
        settings = (GameSettings)ScriptableObject.CreateInstance(typeof(GameSettings));


        // Creates InputManager
        if (!GameObject.FindObjectOfType<InputManager>())
        {
            GameObject inputManagerObject = new GameObject("InputManager");
            inputManagerObject.AddComponent<InputManager>();
        }

        // Creates SceneSettingManager
        if (!GameObject.FindObjectOfType<SceneSettingManager>())
        {
            GameObject sceneSettingManagerObject = new GameObject("SceneSettingManager");
            sceneSettingManagerObject.AddComponent<SceneSettingManager>();
        }

        // Creates SceneLoader
        if (!GameObject.FindObjectOfType<SceneLoader>())
        {
            GameObject sceneLoaderObject = new GameObject("SceneLoader");
            sceneLoaderObject.AddComponent<SceneLoader>();
        }
    }
}
