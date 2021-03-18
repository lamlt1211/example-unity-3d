using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Vector3 endPos;
    Vector3 startPos;
    public LineRenderer lr;
    Vector3 camOffset = new Vector3(0, 0, 10); // gán tọa độ x,y,z
    bool moving = false;
    public GameObject lastInteractGameObject;
    public GameObject sphere;

    public bool startMovingLineRenderer = false;
    public int lastPointIndex; // điểm cuối cùng

    public bool click = false;
    void Start()
    {
        position = new Vector3[3];
        lr.positionCount = 2;
        lr.SetPosition(0, sphere.transform.position);
        lr.SetPosition(1, sphere.transform.position);
        lastPointIndex = 1;
    }

    private Vector3[] position;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            moving = Physics.Raycast(ray, out hit);
            if (moving) // xử lý kéo chuột
            {
                if (lastInteractGameObject != hit.transform.gameObject)
                {
                    lastInteractGameObject = hit.transform.gameObject;
                    if (lastInteractGameObject.tag == "Starts")
                    {
                        startMovingLineRenderer = true; // == true thì có thể kéo
                    }

                    if (lastInteractGameObject.tag == "Anchor")
                    {
                        if (startMovingLineRenderer)
                        {
                            lr.SetPosition(lastPointIndex, hit.transform.position); // nhận điểm thả chuột
                            lr.positionCount++; // tang so diem cua lr 
                            //diem cuoi cung cua mang position lr, bắt vào object, nếu không có thì ko thể bắt object
                            lastPointIndex = lr.positionCount - 1;
                        }

                    }
                    if (lastInteractGameObject.tag == "End")
                    {
                        if (startMovingLineRenderer)
                        {
                            lr.SetPosition(lastPointIndex, hit.transform.position);
                            startMovingLineRenderer = false; // dừng không kéo được nữa
                        }
                    }
                }
            }
            if (startMovingLineRenderer)
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                lr.SetPosition(lastPointIndex, startPos);
            }


        }
    }
}
