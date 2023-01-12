using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    CharacterController CharacterControllerPlayer;

    float Speed = 3f;

    float pitch = 0f;

    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        CharacterControllerPlayer = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        Look();

        if (this.transform.position.y < -2) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    void MovePlayer() {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = Vector3.ClampMagnitude(move, 1f);

        move = transform.TransformDirection(move);

        CharacterControllerPlayer.SimpleMove(move * Speed);

    }

    float Sensitivity = 3f;

    float MinPitch = -45f;

    float MaxPitch = 45f;

    void Look() {

        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;

        transform.Rotate(0, mouseX, 0);

        pitch -= Input.GetAxis("Mouse Y") * Sensitivity;

        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);

    }
}
