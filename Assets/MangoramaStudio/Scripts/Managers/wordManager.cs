using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wordManager : CustomBehaviour
{

    public static string CurrentWord;

    public TextMesh WordTextMesh;
    public AnswerList Answerlist;
    private float flag = 0;

    //private void Start()
    //{
    //    txt.text = currentWord;
    //}


    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        WordTextMesh.text = CurrentWord;
        
    }

    public void UpgradeText()
    {
        WordTextMesh.text = CurrentWord;
    }

    [System.Obsolete]
    public void CheckWord()
    {
        
        for (int i = 0; i < Answerlist.Answers.Count; i++)
        {
            
            string indexWord = Answerlist.Answers[i].GetComponent<TextMeshPro>().text;
           if( CurrentWord == indexWord)
            {
                if (!Answerlist.Answers[i].active)
                {
                Answerlist.Answers[i].SetActive(true);
                Debug.Log("baþardýn");
                flag++;
                }
                
            }
        }
        
        if (flag == Answerlist.Answers.Count)
        {
            Debug.Log("LEVEL FINISHED");
            GameManager.EventManager.LevelCompleted();
            flag = 0;
        }

       
    }

}

