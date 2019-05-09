using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool firing = false;
    private LineRenderer lineRenderer;
    private Transform holder;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        holder = transform.parent;
    }

    public void Fire() {
        if (!firing) {
            StartCoroutine("FireGun");
        }
    }

    IEnumerator FireGun() {
        firing = true;
        lineRenderer.enabled = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, holder.forward, out hit, 50f)) {
            Debug.Log("Hit object: " + hit.transform.gameObject.name);
        }

        yield return new WaitForSeconds(0.05f);
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(0.05f);
        firing = false;
    }
}
