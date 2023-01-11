using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    CharacterController controller;
    float heading;
    public float directionChangeInterval = 1f;
    public float maxHeadingChange = 30;
    Vector3 targetRotation;
    public float speed = 1f;


    void Awake()
    {
        controller = GetComponent<CharacterController>();

        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    IEnumerator NewHeading()
    {
        while(true) 
        {
            NowHeadingRoutine();

            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void NowHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);

        var ceiling = Mathf.Clamp(heading + maxHeadingChange, 0, 360);

        heading = Random.Range(floor, ceiling);

        targetRotation = new Vector3(0, heading, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);

        var forward = transform.TransformDirection(Vector3.forward);

        controller.SimpleMove(forward * speed);

        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
