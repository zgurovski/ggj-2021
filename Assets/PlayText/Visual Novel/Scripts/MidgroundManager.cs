using PlayTextSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidgroundManager : MonoBehaviour
{
    public List<GameObject> CharacterList;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("NextDialogue", NextDialogue);
        //EventCenter.GetInstance().AddEventListener("PlayText.Player.None", Asen);
        EventCenter.GetInstance().AddEventListener("PlayerOn", PlayerOn);
        EventCenter.GetInstance().AddEventListener("MalinaOn", MalinaOn);
        //EventCenter.GetInstance().AddEventListener("PlayText.Malina.None", Malina);
    }

    public void Update()
    {

    }

    public void PlayerOn()
    {
        CharacterList[0].SetActive(true);
        CharacterList[1].SetActive(false);
    }
    public void MalinaOn()
    {
        CharacterList[0].SetActive(false);
        CharacterList[1].SetActive(true);
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
