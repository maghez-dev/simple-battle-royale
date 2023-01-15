using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public ParticleSystem bulletParticleSystem;

    private ParticleSystem.EmissionModule em;
    private int raycastLenght = 10;
    private float fireRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, raycastLenght))
        {
            Attack();

            em.rateOverTime = fireRate;
        } else
        {
            em.rateOverTime = 0;
        }
    }

    void Attack()
    {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);

        float rayLenght = 100f;
        if (Physics.Raycast(ray, out RaycastHit hit, rayLenght))
        {
            var ojectHit = hit.collider.GetComponent<PlayerHealth>();

            if (ojectHit != null)
            {
                float reduceHealthBy = 10f;
                ojectHit.ReduceHealth(reduceHealthBy);
            }
        }
    }
}
