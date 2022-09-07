using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControl : MonoBehaviour
{

    [SerializeField] private lrcontroller lrController;


    private void OnMouseDown()
    {
        wordManager.currentWord += GetComponent<TextMesh>().text;
        Debug.Log(wordManager.currentWord);
    }

    private void OnMouseEnter()
    {
        //Debug.Log(GetComponent<Transform>().position);
        lrController.onLineTouchWithLetter(GetComponent<Transform>());
       // Debug.Log(GetComponent<TextMesh>().text);
        wordManager.currentWord += GetComponent<TextMesh>().text;
        

    }









}
