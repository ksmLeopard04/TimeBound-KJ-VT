using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;
    public TextMeshProUGUI level2;
    public TextMeshProUGUI level3;
    public bool selectedLevel2First;
    public bool selectedLevel3First;
    public string level2Text;
    public string level3Text;
    public string companion;

    private void Awake()
    {
        if (instance == null) // If there is not yet a gamemanager then this object
                                    // will be the gamemanager.
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this) // If there is already a gamemanager then destroy
                                         // this object. There should only ever be one.
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(level2 != null && level3 != null)
        {
            if(selectedLevel2First)
            {
                level2Text = "You meet your companion Bob. He is from the same school as you and has also gotten mysterious powers. He is very emphatetic and often thinks low of himself. His abilities are slower but more heavy hitting.";
                companion = "Bob";
            }
            else
            {
                level2Text = "You meet your companion Sarah. She is from the same school as you and has also gotten mysterious powers. She is one of the popular kids and has high goals for herself. Her abilities are more agile but less damaging.";
                companion = "Sarah";
            }
            if(selectedLevel3First)
            {
                level3Text = "Your companion, [REDACTED], has been abducted by powerful forces right in front of you. Do something before it is too late.";
            }
            else
            {
                level3Text = $"Your companion, {companion}, has been abducted by powerful forces right in front of you. Do something before it is too late.";
            }
        }
    }
    public void SelectLevel3()
    {
        if(selectedLevel2First == false)
        {
            selectedLevel3First = true;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = level3Text;
        }
        else
        {
            selectedLevel3First=false;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = level3Text;
        }
    }
    public void SelectLevel2()
    {
        if (selectedLevel3First == false)
        {
            selectedLevel2First = true;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = level2Text;
        }
        else
        {
            selectedLevel2First = false;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = level2Text;
        }
    }
    public void PlayEndless()
    {

    }
    public void PlayLevel1()
    {

    }
}
