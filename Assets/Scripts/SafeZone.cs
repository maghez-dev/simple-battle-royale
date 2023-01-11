using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private Vector3 scaleChange;
    private float minimumGroundLenght;

    // Start is called before the first frame update
    void Start()
    {
        float scaleAmount = 0.01f;

        scaleChange = new Vector3(scaleAmount, 0, scaleAmount);

        minimumGroundLenght = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= minimumGroundLenght)
        {
            return;
        }
        
        transform.localScale -= scaleChange;
    }
}
