using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetController : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().sharedMaterial;
        savedOffset = mat.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        mat.SetTextureOffset("_MainTex", offset);
    }

    //void OnDisable()
    //{
    //    renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    //}   
}
