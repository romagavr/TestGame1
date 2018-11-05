using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovingScript : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    //public GameObject wagon;

    //void Start()
    //{
    //    wagon = GameObject.Find("wagon1");
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        OnMouseDown();
    //        OnMouseDrag();
    //    }
    //}

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
        Debug.Log("x: " + Input.mousePosition.x);
    }
    //   private float deltaX, deltaY;

    //   Rigidbody rb;

    //   // Use this for initialization
    //   void Start () {
    //       rb = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update () {

    //       //if (Input.touchCount > 0)
    //       //{
    //       //    Touch touch = Input.GetTouch(0);
    //       //    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

    //       //    switch (touch.phase)
    //       //    {
    //       //        case TouchPhase.Began:
    //       //            deltaX = touchPos.x - transform.position.x;
    //       //            deltaY = touchPos.y - transform.position.y;
    //       //            break;

    //       //        case TouchPhase.Moved:
    //       //            // transform.position = startPosition + Vector3.forward * newPosition + new Vector3(deltaX, 0, 0);
    //       //            rb.MovePosition(new Vector3(touchPos.x - deltaX, 0, 0));
    //       //            break;

    //       //    }
    //       //}
    //       //else
    //       //{
    //       // //   transform.position = startPosition + Vector3.forward * newPosition;
    //       //}

    //       if (Input.GetMouseButtonDown(0))
    //       {
    //           Vector3 mouse = Input.mousePosition;
    //           Ray castPoint = Camera.main.ScreenPointToRay(mouse);
    //           RaycastHit hit;
    //           if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
    //           {
    //               transform.position = hit.point;
    //           }
    //       }
    //   }
}
