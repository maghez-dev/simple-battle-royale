using Unity.Netcode;
using UnityEngine;


public class PlayerMovement : NetworkBehaviour
{
    [Header("XZ Movement")]
    public float speed = 10f;

    [Header("Jump")]
    public float jumpForce = 5f;

    [Header("Look Around")]
    public float sensitivity = 1f;
    public float lerp = 1f;
    [Range(0, 90)] public int maxAngle = 70;
    [Range(-90, 0)] public int minAngle = -70;
    public GameObject playerCamera;

    private Rigidbody rb;
    private float rotatedX = 0f;
    private float rotatedY = 0f;


    void Start()
    {
        if (IsOwner)
            playerCamera.SetActive(true);

        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        if (!IsOwner) return;

        Jump();

        LookAround();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        Movement();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void LookAround()
    {
        float rotX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float rotY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotatedX += rotX;
        rotatedY -= rotY;
        rotatedX %= 360;
        rotatedY %= 360;

        if (rotatedY > maxAngle)
            rotatedY = maxAngle;
        if (rotatedY < minAngle)
            rotatedY = minAngle;

        Quaternion targetRotation = Quaternion.Euler(rotatedY, rotatedX, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerp * Time.deltaTime);
    }

    private void Movement()
    {
        Vector3 horizontal = transform.right * Input.GetAxis("Horizontal");
        Vector3 forward = transform.forward * Input.GetAxis("Vertical");

        Vector3 xzVelocity = (horizontal + forward).normalized * speed * Time.fixedDeltaTime;

        rb.velocity = new Vector3(xzVelocity.x, rb.velocity.y, xzVelocity.z);
    }
}
