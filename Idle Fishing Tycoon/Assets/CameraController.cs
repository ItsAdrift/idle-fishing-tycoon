using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isRotating;
    private bool isPanning;
    private float velocity;
    private float zoomVelocity;

    private float deltaX = 0f;
    private float deltaY = 0f;

    [SerializeField] float deltaSpeed = 3f;
    [SerializeField] float lerpSpeed = 5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isPanning = true;
            deltaX = 0f;
            deltaY = 0f;
        }
        else
        {
            isPanning = false;
            //deltaX = 0f;
            //deltaY = 0f;
        }

        if (isPanning == true)
        {
            PanCameraTarget();
        }

        CalculatePan();
    }

    void CalculatePan()
    {
        if (deltaX < 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, 0);
        }

        if (deltaX > 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, 0);
        }

        if (deltaY < 0)
        {
            Camera.main.transform.parent.Translate(0, -deltaY, 0);
        }

        if (deltaY > 0)
        {
            Camera.main.transform.parent.Translate(0, -deltaY, 0);
        }

        deltaY = Mathf.Lerp(deltaY, 0f, Time.deltaTime * lerpSpeed);
        deltaX = Mathf.Lerp(deltaX, 0f, Time.deltaTime * lerpSpeed);
    }

    void PanCameraTarget()
    {
        deltaX = Input.GetAxisRaw("Mouse X") * deltaSpeed;
        deltaY = Input.GetAxisRaw("Mouse Y") * deltaSpeed;
    }
}

