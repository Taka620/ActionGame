using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Transform wayPointList;
    private List<Transform> wayPoints = new List<Transform>();
    private float lastMoveTime = 0;
    private float moveCoolTime = 5;
    private float moveSpeed = 6;
    private Transform currentTarget;

    private void Start() 
    {
        for (int i = 0; i < wayPointList.childCount; i++)    
        {
            wayPoints.Add(wayPointList.GetChild(i).transform);
        }
    }

    private void Update() 
    {
        if (Time.time - lastMoveTime > moveCoolTime)
        {
            if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                int rand = UnityEngine.Random.Range(0, wayPointList.childCount);
                currentTarget = wayPoints[rand];
                lastMoveTime = Time.time;
            }
        }

        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}

