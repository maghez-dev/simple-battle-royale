using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    private Vector3 ScaleChange;

    private float MinimumGroundLength;

    // Start is called before the first frame update
    void Start()
    {
        float scaleByAmount = 0.01f;

        ScaleChange = new Vector3(scaleByAmount, 0, scaleByAmount);

        MinimumGroundLength = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x <= MinimumGroundLength) { 

            return;
        }

        this.transform.localScale -= ScaleChange;
    }
}
