using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControl : MonoBehaviour
{
    public bool IsLetterAdded;

    [SerializeField] private lrcontroller _lrController;
    

    private void OnMouseDown()
    {
        _lrController.IsInputActive = true;
        wordManager.CurrentWord += GetComponent<TextMesh>().text;
        _lrController.OnLineTouchWithLetter(GetComponent<Transform>());
        
        IsLetterAdded = true;
    }

   

    private void Start()
    {
        _lrController.GameManager.EventManager.OnLineReset += resetIsLetterAddedBool;
    }

    private void OnMouseEnter()
    {
        //Debug.Log(GetComponent<Transform>().position);
        
       // Debug.Log(GetComponent<TextMesh>().text);
       if (_lrController.IsClicking && !IsLetterAdded)
        {

        wordManager.CurrentWord += GetComponent<TextMesh>().text;
        _lrController.OnLineTouchWithLetter(GetComponent<Transform>());
            IsLetterAdded = true;
        }

       if (IsLetterAdded)
        {
            _lrController.IsBackToActiveLetter = true;
        }

    }

    private void OnMouseExit()
    {
        if (IsLetterAdded)
        {
           
            _lrController.IsBackToActiveLetter = false;
        }
    }


    private void resetIsLetterAddedBool()
    {
        IsLetterAdded = false;
    }






}
