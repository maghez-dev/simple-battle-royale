using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    
    CharacterController characterController;
    float speed = 3f;
    float sensitivity = 1f;

    float pitch = 0f;
    float minPitch = -45f;
    float maxPitch = 45f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();

        Look();
    }

    void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f);
        move = transform.TransformDirection(move);

        characterController.SimpleMove(move * speed);
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        transform.Rotate(0, mouseX, 0);

        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
