using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public List<Letter> letterList = new List<Letter>();

    void Start()
    {
     InitializeLetters();   
    }

    void Update()
    {
        
    }
    void InitializeLetters()
    {
        letterList.Add(new Letter {childName = "Eva", content = "This is my second christmas, my name is Eva and I want two pink butterflies. I love you Santa."});
        //letterList.Add(new Letter {name = "Eva", content = "This is my second christmas, my name is Eva and I want two pink butterflies. I love you Santa."});
    }
    /*public string GetRandomLetter()
    {
        if(letterList.Count == 0)
        {
            Debug.LogWarning("No letters available");
            return null;
        }
        int randomIndex = Random.Range(0,0);
        return letterList[randomIndex].content;
    }*/
    public string GetLetterContent()
    {
        int letterIndex = 0;
        return letterList[letterIndex].content;
    }
    
}
