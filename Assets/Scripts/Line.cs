using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer line;
    private Vector3 pre;
    public float min = 0.1f;
    [SerializeField, Range(0.1f, 2f)]
    private float width;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        line.startWidth = line.endWidth = width;
    }
    public void StartLine(Vector2 pos)
    {
        line.positionCount= 1;
        line.SetPosition(0, pos);
    }
    public void UpdateLine()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 curr =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curr.z= 0;
            if(Vector3.Distance(curr,pre)> min)
            {
                if(pre==transform.position)
                {
                    line.SetPosition(0, curr);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, curr);
                }
                pre= curr;
            }
        }
    }
}
