using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingScript : MonoBehaviour {

    private Vector3 startPosition;
    public static float scrollSpeed = 2;
    public float tileSizeZ;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
