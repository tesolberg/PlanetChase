using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public Weapon weapon;


    private void Update() {

        UpdatePosition();
        UpdateRotation();

        if (Input.GetAxis("Fire4") > .2 && weapon != null) {
            weapon.Fire();
        }
    }

    private void UpdatePosition() {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        // Vector3 movementVector = Quaternion.Euler(0, 135, 0) * new Vector3(x * movementSpeed, transform.position.y, z * movementSpeed);
        Vector3 movementVector = new Vector3(x * movementSpeed, transform.position.y, z * movementSpeed);

        transform.position += movementVector;
    }

    private void UpdateRotation() {
        float x = Input.GetAxis("HorizontalR");
        float z = Input.GetAxis("VerticalR");

        if (Math.Abs(x + z) < .1f) {
            return;
        }

        float heading = Mathf.Atan2(z, x);

        transform.rotation = Quaternion.Euler(0f,heading*Mathf.Rad2Deg, 0f) * Quaternion.Euler(0f,90f,0f);
    }
}
