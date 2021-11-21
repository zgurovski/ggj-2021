using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayTextSupport;

public class Cinematic : MonoBehaviour
{
    public List<GameObject> CharacterList;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("PlayText.NextDialogue", NextDialogue);
        EventCenter.GetInstance().AddEventListener("PlayText.Asen.None", Asen);
        EventCenter.GetInstance().AddEventListener("PlayText.Malina.None", Malina);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextDialogue()
    {
        for (int i = 0; i < CharacterList.Count; i++)
        {
            CharacterList[i].SetActive(false);
        }
    }

    void Asen() => CharacterList[0].SetActive(true);

    void Malina() => CharacterList[1].SetActive(true);

}
