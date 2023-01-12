using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{ 
    public ParticleSystem bulletParticleSystem;
    private ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    private int RaycastLength = 10;

    private float FiringRate = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, RaycastLength)) {

            Attack();

            em.rateOverTime = FiringRate;

        } else {

            em.rateOverTime = 0f;

        }
    }

    void Attack() {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);

        float rayLength = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength)) {

            var objectHit = hit.collider.GetComponent<PlayerHealth>();

            if (objectHit != null) {

                objectHit.ReduceHealth(10f);

            } 
        }
    }
}
