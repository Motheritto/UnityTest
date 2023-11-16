using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    float xRotation = 0f;

    [Header("Чувствительность мыши")]
    public float sensitivity = 2f;

    public Transform Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity;

        Player.Rotate(MouseX * new Vector3(0, 1, 0));

        transform.Rotate(MouseY * new Vector3(-1, 0, 0));

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
