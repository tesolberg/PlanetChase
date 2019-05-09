using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 100f, transform.position);

        foreach (RaycastHit hit in hits) {
            if (hit.transform.CompareTag("Player")) {
                target = hit.transform;
                Debug.Log("Player found");
            }
        }
        agent.SetDestination(target.position);
    }

    private void Update() {
        agent.SetDestination(target.position);
    }



}
