using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovingWagonScript : MonoBehaviour {

    private float DELTA_MOVE = 1f;
	public float scrollSpeed;
    public float tileSizeZ;
   // private Vector3 rightOffset;

    private Vector3 startPosition;
    private Camera cam;
    public Vector3 bridgeSize;
    private float deltaX, deltaY;
    private Vector2 startPosTouch, direction;
    bool directionChosen=false;


	 void Start ()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        bridgeSize = GameObject.Find("Bridge_Large").transform.FindChild("Bridge").GetComponent<BoxCollider>().size;
        startPosition = transform.position;
    }

    void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch: ");
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
            Debug.Log("x: " + touch.position.x);
            Debug.Log("x1: " + touchPos.x);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPosTouch = touch.position;
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPosTouch;
                    break;
                //   startPosition.x = touchPos.x;
                // transform.position = startPosition + Vector3.forward * newPosition + new Vector3(deltaX, 0, 0);
                // rb.MovePosition(new Vector3(touchPos.x - deltaX, 0, 0));
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }

            if (directionChosen)
            {
                if (direction.x > 0)
                {
                    startPosition.x += DELTA_MOVE;
                } else
                {
                    startPosition.x -= DELTA_MOVE;
                }
                directionChosen = false;
            }
        }
        else
        {
            //   transform.position = startPosition + Vector3.forward * newPosition;
        }
    }

        /*   	float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
               if (Input.GetMouseButtonDown(0))
               {
                   rightOffset += Vector3.right;
                   transform.position = startPosition + Vector3.forward * newPosition + rightOffset;
               } else {
                   transform.position = startPosition + Vector3.forward * newPosition + rightOffset;
               }	*/
        //float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        //transform.position = startPosition + Vector3.forward * newPosition;

    }

//    private Vector3 screenPoint;
//    private Vector3 offset;

//    void OnMouseDrag()
//    {
//        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f);
//        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
//        transform.position = cursorPosition;
//        Debug.Log("x: " + Input.mousePosition.x);
//    }

//    void OnMouseDown()
//    {
//        Debug.Log("x: ");
//    }

//}