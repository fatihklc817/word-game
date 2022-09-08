using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControl : MonoBehaviour
{

    [SerializeField] private lrcontroller _lrController;


    private void OnMouseDown()
    {
        _lrController.IsInputActive = true;
        wordManager.CurrentWord += GetComponent<TextMesh>().text;
        _lrController.OnLineTouchWithLetter(GetComponent<Transform>());
        Debug.Log(wordManager.CurrentWord);
    }

    private void OnMouseEnter()
    {
        //Debug.Log(GetComponent<Transform>().position);
        
       // Debug.Log(GetComponent<TextMesh>().text);
       if (_lrController.IsClicking)
        {

        wordManager.CurrentWord += GetComponent<TextMesh>().text;
        _lrController.OnLineTouchWithLetter(GetComponent<Transform>());

        }
    }









}
