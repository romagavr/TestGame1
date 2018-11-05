using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScalerComponent : MonoBehaviour {

    private Camera _camera;

    private const float DefaultAspectRatio = 1.775f; // iPhone 5 landscape ratio
    private const float DefaultOrthographicSize = 4f;

    float resolutionWidth = 1920.0f;
    float resolutionHeight = 1080.0f;

    private void Awake()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //_camera.orthographicSize = DefaultOrthographicSize;

        _camera.projectionMatrix = Matrix4x4.TRS(
        new Vector3(0, 0, 0),
        Quaternion.identity,
        new Vector3(
            Screen.width / resolutionWidth,
            Screen.height / resolutionHeight,
            1.0f));

        //_camera.projectionMatrix = Matrix4x4.Ortho(
        //-DefaultOrthographicSize * DefaultAspectRatio,
        //DefaultOrthographicSize * DefaultAspectRatio,
        //-DefaultOrthographicSize, DefaultOrthographicSize,
        //_camera.nearClipPlane, _camera.farClipPlane);
    }
}
