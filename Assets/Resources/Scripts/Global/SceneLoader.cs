using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public enum Scene
    {
        THE_NEIGHBOURHOOD,
        THE_SCRAPYARD
    }

    public static Dictionary<Scene, string> sceneToSceneName = new Dictionary<Scene, string>
    {
        {Scene.THE_NEIGHBOURHOOD, "TheNeighbourhood"},
        {Scene.THE_SCRAPYARD, "TheScrapyard"},
    };

    public static Scene getSceneByName(string sceneName)
    {
        foreach (KeyValuePair<Scene, string> currentScene in sceneToSceneName)
        {
            if (sceneName.Equals(currentScene.Value))
            {
                return currentScene.Key;
            }
        }
        return Scene.THE_NEIGHBOURHOOD;
    }

    public static string getSceneNameByScene(Scene scene)
    {
        foreach (KeyValuePair<Scene, string> currentScene in sceneToSceneName)
        {
            if (scene == currentScene.Key)
            {
                return currentScene.Value;
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LoadScene(string sceneName)
    {
        // Give some time for the effects to render, then change to a new scene
     //   string sceneName = getSceneNameByScene(scene);
        StartCoroutine(ChangeScene(sceneName, 1f));
    }

    IEnumerator ChangeScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
