using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrcontroller : MonoBehaviour
{
    [SerializeField] wordManager wordManager;
    public LineRenderer lr;
    private List<Vector3> points;
    private bool isHavingPoint=false;
    Vector3 worldPos;
    Vector3 targetPos;
    int currentPointIndex;

    private void Start()
    {
        points = new List<Vector3>();
        
    }
    private void SetPoints()
    {
        lr.positionCount = points.Count;
        
    }

    private void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            
             worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector3(worldPos.x, worldPos.y, transform.position.z);
            if (!isHavingPoint)
            {
             points.Add(targetPos);
                wordManager.upgradeText();
                SetPoints();
                isHavingPoint = true;
            }
            currentPointIndex = points.Count - 1;
            points[currentPointIndex] = targetPos;
                
                for (int i = 0; i < points.Count; i++)
                {
                    lr.SetPosition(i, points[i]);
                }
                

            

                

        }

 
    }



    public void onLineTouchWithLetter(Transform letterTransform)                  
    {

       
        {
            Vector3 pos = letterTransform.position;
            points[currentPointIndex] = new Vector3(pos.x, pos.y, transform.position.z);
            isHavingPoint = false;
            
        }
    }


}
