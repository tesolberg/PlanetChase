using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public int weaponDamage;

    private bool firing = false;
    private LineRenderer lineRenderer;
    private Transform holder;
    LayerMask entityLayer;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        holder = transform.parent;
        entityLayer = LayerMask.GetMask("Entities");
    }

    public void Fire() {
        if (!firing) {
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack() {
        firing = true;
        lineRenderer.enabled = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, holder.forward, out hit, 50f, entityLayer)) {
            Debug.Log("Hit object: " + hit.transform.name);
            Health enemyHealth = hit.transform.GetComponent<Health>();
            if (enemyHealth) {
                enemyHealth.Hit(weaponDamage);
            }
        }

        yield return new WaitForSeconds(0.05f);
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        firing = false;
    }
}
