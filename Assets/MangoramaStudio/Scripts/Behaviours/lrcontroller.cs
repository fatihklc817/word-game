using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrcontroller : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public bool IsClicking;
    public bool IsInputActive=false;
    
    [SerializeField] wordManager wordManager;
    
    private List<Vector3> _lineRendererGoalpoints;
    private bool _isHavingPoint = false;
    private Vector3 _worldPos;
    private Vector3 _targetMousePos;
    private int _currentPointIndex;


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
            
                if (!_isHavingPoint)
                {
                    _lineRendererGoalpoints.Add(_targetMousePos);
                    wordManager.UpgradeText();
                    SetPoints();
                    _isHavingPoint = true;
                }

                _currentPointIndex = _lineRendererGoalpoints.Count - 1;
                _lineRendererGoalpoints[_currentPointIndex] = _targetMousePos;

                for (int i = 0; i < _lineRendererGoalpoints.Count; i++)
                {
                    LineRenderer.SetPosition(i, _lineRendererGoalpoints[i]);
                    LineRenderer.alignment = LineAlignment.Local;
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
                IsClicking = false;
            }

        }
    }



    public void OnLineTouchWithLetter(Transform letterTransform)
    {
        {
            Vector3 pos = letterTransform.position;
            _lineRendererGoalpoints[_currentPointIndex] = new Vector3(pos.x, pos.y, transform.position.z);
            _isHavingPoint = false;

        }
    }


}
