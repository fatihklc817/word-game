using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrcontroller : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public bool IsClicking;
    public bool IsInputActive=false;
    public bool IsBackToActiveLetter;
    
    
    [SerializeField] wordManager wordManager;
    
    private List<Vector3> _lineRendererGoalpoints;
    private bool _isHavingPoint = false;
    private Vector3 _worldPos;
    private Vector3 _targetMousePos;
    private int _currentPointIndex;
    private Vector3 _currentLetterTransform;
    public GameManager GameManager;




    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    private void Start()
    {
        _lineRendererGoalpoints = new List<Vector3>();
        _lineRendererGoalpoints.Add(new Vector3(0, -1.6f, 0));
        SetPoints();
    }
    private void SetPoints()
    {
        LineRenderer.positionCount = _lineRendererGoalpoints.Count;

    }

    private void Update()
    {
        
        if (IsInputActive)
        {

            if (Input.GetMouseButton(0))
            {
                IsClicking = true;
                _worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _targetMousePos = new Vector3(_worldPos.x, _worldPos.y, transform.position.z);
            
                if (!_isHavingPoint )
                {
                    _lineRendererGoalpoints.Add(_targetMousePos);
                    wordManager.UpgradeText();
                    SetPoints();
                    _isHavingPoint = true;
                }

                _currentPointIndex = _lineRendererGoalpoints.Count - 1;
                if (!IsBackToActiveLetter)
                {
                _lineRendererGoalpoints[_currentPointIndex] = _targetMousePos;
                }
                else if(IsBackToActiveLetter)
                {
                    _lineRendererGoalpoints[_currentPointIndex] = _currentLetterTransform;
                }

                for (int i = 0; i < _lineRendererGoalpoints.Count; i++)
                {
                    LineRenderer.SetPosition(i, _lineRendererGoalpoints[i]);
                    LineRenderer.alignment = LineAlignment.Local;
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
                IsClicking = false;
                GameManager.EventManager.ResetLine();
                _lineRendererGoalpoints.Clear();
                _lineRendererGoalpoints = new List<Vector3>();
                _lineRendererGoalpoints.Add(new Vector3(0, -1.6f, 0));
                _currentPointIndex = 0;
                

                SetPoints();

            }

        }
    }



    public void OnLineTouchWithLetter(Transform letterTransform)
    {


        _currentLetterTransform = new Vector3(letterTransform.position.x, letterTransform.position.y, transform.position.z);
            Vector3 pos = letterTransform.position;
            _lineRendererGoalpoints[_currentPointIndex] = new Vector3(pos.x, pos.y, transform.position.z);
            _isHavingPoint = false;
           

        
    }


}
