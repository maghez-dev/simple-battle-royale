using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool attacking = false;
    public ParticleSystem bulletParticleSystem;
    private ParticleSystem.EmissionModule em;
    float attackTimer = 0f;
    private float fireRate = 10f;

    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    void Update()
    {
        attacking = Input.GetMouseButton(0);

        attackTimer += Time.deltaTime;

        if (attacking && attackTimer >= 1f/fireRate)
        {
            attackTimer = 0f;
            Attack();
        }

        em.rateOverTime = attacking? fireRate : 0f;
    }

    private void Attack()
    {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);

        float raycastLenght = 100f;
        if (Physics.Raycast(ray, out RaycastHit hit, raycastLenght))
        {
            var playerHitHealth = hit.collider.GetComponent<PlayerHealth>();

            if (playerHitHealth != null)
            {
                float reduceHealthBy = 10f;
                playerHitHealth.ReduceHealth(reduceHealthBy);
            }
        }
    }
}
