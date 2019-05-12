using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float turnRate;
    public int damage;
    public int RPM;
    public float range;

    public Transform target;

    private Weapon weapon;
    LayerMask enemyLayer;

    private void Start() {
        weapon = GetComponentInChildren<Weapon>();
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

    void UpdateRotation() {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }


    bool WithingRange(Transform target_) {
        float distance = Vector3.Magnitude(transform.position - target_.position);
        return distance <= range;
    }

    Transform SelectTarget() {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, range, transform.position, enemyLayer);
        foreach (RaycastHit hit in hits) {
            if (hit.transform.CompareTag("Enemy")) {
                return hit.transform;
            }
        }
        return null;
    }

}
