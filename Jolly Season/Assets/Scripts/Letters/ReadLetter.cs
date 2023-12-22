using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ReadLetter : MonoBehaviour
{
    
    public LetterManager letterManager;
    public TextMeshProUGUI letterText;
    public GameObject letter;
    [SerializeField] KeyCode readLetter = KeyCode.H;
    [SerializeField] KeyCode closeLetter = KeyCode.J;
    public bool letterRead = false;

    void Start()
    {
       
    }

    void Update()
    {
        LetterOpenClose();
        //IfReadLetter();
    }

    void LetterOpenClose()
    {
        if (Input.GetKeyDown(readLetter))
        {
            
            Invoke("ReadLetters",0.1f);
            letter.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(closeLetter))
        {
            letterRead = true;
            letter.gameObject.SetActive(false);
        }
    }
    public void ReadLetters()
    {
        string randomLetterContent = letterManager.GetLetterContent();
        if (randomLetterContent != null)
        {
            letterText.text = randomLetterContent;            
        }
    }
    /*public void IfReadLetter()
    {
        if(letterRead == true)
        uIManager.TurnOnPresentNumberUI();
    }*/
}

