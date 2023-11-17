using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Скорость игрока")]
    public float Speed = 6f;
    public float RotationSpeed = 10f;

    [SerializeField]private Rigidbody rb;

    private void Start()
    {
        rb.centerOfMass = Vector3.zero;
    }

    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Horizontal");
        float sideInput = Input.GetAxis("Vertical");
        float mouseInput = Input.GetAxis("Mouse X");

        Vector3 movement = new Vector3(forwardInput, 0, sideInput) * Speed;
//        movement.y = rb.velocity.y;
        Vector3 worldmovement = transform.TransformVector(movement);
        rb.velocity = worldmovement;

        rb.angularVelocity = new Vector3(0f, mouseInput * RotationSpeed, 0f);
    }
}