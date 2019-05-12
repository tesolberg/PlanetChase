using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float cooldown;
    public float attackRange;
    public int attackDamage;

    NavMeshAgent agent;
    float cooldownTimer = 0f;
    
    private void Start() {
        agent = GetComponent<NavMeshAgent>();

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 100f, transform.position);

        foreach (RaycastHit hit in hits) {
            if (hit.transform.CompareTag("Player")) {
                target = hit.transform;
                //Debug.Log("Player found");
            }
        }
        agent.SetDestination(target.position);
    }

    private void Update() {
        agent.SetDestination(target.position);

        CheckAttack();
    }

    private void CheckAttack() {
        cooldownTimer -= Time.deltaTime;

        float distanceToTarget = (transform.position - target.position).magnitude;
        if (distanceToTarget < attackRange && cooldownTimer <= 0f) {
            target.parent.GetComponent<Health>().Hit(attackDamage);
            cooldownTimer = cooldown;
        }
    }
}
