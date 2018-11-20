using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barier")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collision!!!!!!!!!!!!!!");
        }
    }
}
