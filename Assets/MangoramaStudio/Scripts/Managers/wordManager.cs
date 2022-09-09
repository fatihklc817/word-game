using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordManager : CustomBehaviour
{

    public static string CurrentWord;

    [SerializeField] private TextMesh _WordTextMesh;
    [SerializeField] private AnswerList _answerList;

    //private void Start()
    //{
    //    txt.text = currentWord;
    //}

    
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        _WordTextMesh.text = CurrentWord;
        
    }

    public void UpgradeText()
    {
        _WordTextMesh.text = CurrentWord;
    }

    public void CheckWord()
    {
        
        for (int i = 0; i < _answerList.Answers.Count; i++)
        {
            
            string indexWord = _answerList.Answers[i].GetComponent<TextMeshPro>().text;
           if( CurrentWord == indexWord)
            {
                _answerList.Answers[i].SetActive(true);
                Debug.Log("baþardýn");
                
            }
        }
    }

}

