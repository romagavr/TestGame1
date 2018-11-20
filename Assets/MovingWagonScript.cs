using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovingWagonScript : MonoBehaviour {

    private float DELTA_MOVE = 0.4f;
	public float scrollSpeed;
    public float tileSizeZ;
   // private Vector3 rightOffset;

    private Vector3 startPosition;
    private Camera cam;
    public Vector3 bridgeSize;
    private float deltaX, deltaY;
    private Vector2 startPosTouch, direction;
    bool directionChosen=false;

    private float powerInput;
    private float turnInput;
    public float turnSpeed = 0.5f;
    private Rigidbody wagonRigidbody;
    private Rigidbody tLRigidbody;
    private Rigidbody tRRigidbody;

    private int counter=0;
    private bool isCounter = false;
    private float torqueVec;
    private int directionCoef;
    private int framesToTurn = 20;
    private GameObject tigerLeft;
    private GameObject tigerRight;
    private Vector3 tigerLeftStartPosition;
    private Vector3 tigerRightStartPosition;
    private Animation tigerAnimation;


    void Start ()
    {
        tigerLeft = GameObject.Find("tigerLeft");
        tigerRight = GameObject.Find("tigerRight");

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
      //  bridgeSize = GameObject.Find("Bridge_Large").transform.FindChild("Bridge").GetComponent<BoxCollider>().size;
        startPosition = transform.position;
        tigerLeftStartPosition = tigerLeft.transform.position;
        tigerRightStartPosition = tigerRight.transform.position;

        wagonRigidbody = GetComponent<Rigidbody>();
        tLRigidbody = tigerLeft.GetComponent<Rigidbody>();
        tRRigidbody = tigerRight.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (isCounter) counter++;
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        tigerLeft.transform.position = tigerLeftStartPosition + Vector3.forward * newPosition;
        tigerRight.transform.position = tigerRightStartPosition + Vector3.forward * newPosition;
        if (Input.touchCount > 0)
        {
           // Debug.Log("Touch: ");
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
           // Debug.Log("x: " + touch.position.x);
           // Debug.Log("x1: " + touchPos.x);

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
                   // Debug.Log("Direction " + direction);
                    isCounter = true;
                    directionChosen = true;
                    break;
            }

            if (directionChosen)
            {
                isCounter = true;
                if (Mathf.Abs(direction.x) > 100)
                {
                    if (direction.x > 0)
                    {
                        Debug.Log("Right");
                        directionCoef = 1;
                        torqueVec = DELTA_MOVE * turnSpeed;
                    }
                    else
                    {
                        Debug.Log("Left");
                        directionCoef = -1;
                        torqueVec = -DELTA_MOVE * turnSpeed;
                    }
                } else
                {
                    if (direction.y > 0)
                    {
                        Debug.Log("Up");
                    }
                    else
                    {
                        Debug.Log("Down");
                    }
                }
                directionChosen = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isCounter)
        {
            startPosition.x += (directionCoef * DELTA_MOVE/(framesToTurn * 2 - 1));
            tigerLeftStartPosition.x += (directionCoef * DELTA_MOVE / (framesToTurn * 2 - 1));
            tigerRightStartPosition.x += (directionCoef * DELTA_MOVE / (framesToTurn * 2 - 1));
           // Debug.Log("Counter" + counter);
            if (counter < framesToTurn/2)
            {
                tRRigidbody.AddRelativeTorque(0f, torqueVec, 0f);
                tRRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tRRigidbody.velocity = Vector3.zero;
                tRRigidbody.angularVelocity = Vector3.zero;

                tLRigidbody.AddRelativeTorque(0f, torqueVec, 0f);
                tLRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tLRigidbody.velocity = Vector3.zero;
                tLRigidbody.angularVelocity = Vector3.zero;

                wagonRigidbody.AddRelativeTorque(0f, torqueVec-0.1f, 0f);
                wagonRigidbody.AddRelativeTorque(0f, 0f, 0f);
                wagonRigidbody.velocity = Vector3.zero;
                wagonRigidbody.angularVelocity = Vector3.zero;
            }
            if ((counter >= framesToTurn / 2) && (counter < framesToTurn))
            {
                tRRigidbody.AddRelativeTorque(0f, -torqueVec, 0f);
                tRRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tRRigidbody.velocity = Vector3.zero;
                tRRigidbody.angularVelocity = Vector3.zero;

                tLRigidbody.AddRelativeTorque(0f, -torqueVec, 0f);
                tLRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tLRigidbody.velocity = Vector3.zero;
                tLRigidbody.angularVelocity = Vector3.zero;

                wagonRigidbody.AddRelativeTorque(0f, -torqueVec, 0f);
                wagonRigidbody.AddRelativeTorque(0f, 0f, 0f);
                wagonRigidbody.velocity = Vector3.zero;
                wagonRigidbody.angularVelocity = Vector3.zero;
            }
            if (counter == framesToTurn)
            {
                tRRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tRRigidbody.velocity = Vector3.zero;
                tRRigidbody.angularVelocity = Vector3.zero;

                tLRigidbody.AddRelativeTorque(0f, 0f, 0f);
                tLRigidbody.velocity = Vector3.zero;
                tLRigidbody.angularVelocity = Vector3.zero;
                wagonRigidbody.AddRelativeTorque(0f, 0f, 0f);

                counter = 0;
                isCounter = false;
              //  Debug.Log("Counter end");
                wagonRigidbody.velocity = Vector3.zero;
                wagonRigidbody.angularVelocity = Vector3.zero;
            }
        }

    }
