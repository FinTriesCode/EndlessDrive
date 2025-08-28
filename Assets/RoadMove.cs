using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject[] roadSegments;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject startPos;
    [SerializeField] private GameObject endPos;

    private void Update()
    {
        RoadToCarDistanceCheck(car, roadSegments);
    }

    private void RoadToCarDistanceCheck(GameObject car, GameObject[] roadSegments)
    {
        foreach (GameObject roadSegment in roadSegments)
        {
            roadSegment.transform.position = Vector3.MoveTowards(roadSegment.transform.position, endPos.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(roadSegment.transform.position, endPos.transform.position) < 0.1f)
            {
                roadSegment.transform.position = startPos.transform.position;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPos.transform.position, 0.5f);
        Gizmos.DrawWireSphere(endPos.transform.position, 0.5f);
        Gizmos.DrawLine(startPos.transform.position, endPos.transform.position);
    }
}
