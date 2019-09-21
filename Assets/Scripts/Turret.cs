using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    public float turnRate;
    public int damage;
    public int RPM;
    public float range;

    public Transform target;

    private Weapon weapon;
    LayerMask enemyLayer;
    private NavMeshAgent agent;

    private void Start() {
        weapon = GetComponentInChildren<Weapon>();
        agent = GetComponent<NavMeshAgent>();
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    private void Update() {
        if (target == null || !target.gameObject.activeSelf) {
            target = SelectTarget();
        }
        else {
            UpdateRotation();
            weapon.Fire();
        }
    }

    private void UpdateRotation() {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }


    private bool WithingRange(Transform target_) {
        float distance = Vector3.Magnitude(transform.position - target_.position);
        return distance <= range;
    }

    private Transform SelectTarget() {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, range, transform.position, enemyLayer);
        foreach (RaycastHit hit in hits) {
            if (hit.transform.CompareTag("Enemy")) {
                return hit.transform;
            }
        }
        return null;
    }

    ///////////
    /// API ///
    ///////////

    public void Recall() {

    }

    public void Deploy (Vector3 position) {
        agent.SetDestination(position);
    }

    public void Dismantle() {

    }

    public void MoveTo (Vector3 position) {

    }

}
