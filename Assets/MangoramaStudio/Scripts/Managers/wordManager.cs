using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager : CustomBehaviour
{

    public static string CurrentWord;

    [SerializeField] private TextMesh _WordTextMesh;

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
}

