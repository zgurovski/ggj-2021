using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayTextSupport;

public class Cinematic : MonoBehaviour
{
    public List<GameObject> CharacterList;

    // Start is called before the first frame update
    public void Start()
    {
      //  EventCenter.GetInstance().AddEventListener("PlayText.NextDialogue", NextDialogue);
        EventCenter.GetInstance().AddEventListener("PlayText.Player.None", Asen);
        EventCenter.GetInstance().AddEventListener("PlayText.Malina.None", Malina);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void NextDialogue()
    {
        for (int i = 0; i < CharacterList.Count; i++)
        {
            CharacterList[i].SetActive(false);
        }
    }

    void Asen() => CharacterList[0].SetActive(true);

    void Malina() => CharacterList[1].SetActive(true);

}
