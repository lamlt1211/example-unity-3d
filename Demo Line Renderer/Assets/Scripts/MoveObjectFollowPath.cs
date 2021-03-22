using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFollowPath : MonoBehaviour
{
    [SerializeField] private Vector3[] movePath;
    //[SerializeField] Transform[] Positions;
    public float speed = 6.0f;
    int NextPosIndex;
    Vector3 NextPos;

    //private bool hasInitMoveData = false;
    private bool isMoving = false;
    public Transform[] target;

    private int current;

    public bool startMovingLineRenderer = false;



    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveGameObject();
        }
    }

    void MoveGameObject()
    {
        if (transform.position == NextPos)
        {
            NextPosIndex++;
            if (NextPosIndex < movePath.Length)
            {
                NextPos = movePath[NextPosIndex];
            }
            else
            {
                isMoving = false;
                //Debug.Log("Moving object to move path index " + NextPosIndex);
            }
        }
        else
        {
            //Debug.Log("Moving object to move path index " + NextPosIndex);
            transform.position = Vector3.MoveTowards(transform.position, NextPos, speed * Time.deltaTime);
        }
    }

    public void InitPositionMove(Vector3[] newPos)
    {
        this.movePath = newPos;
        NextPos = movePath[0];
        transform.position = movePath[0];
        NextPosIndex = 0;
        isMoving = true;
    }
}
