using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;

    private void Update() {
        if (PlayerController.p1instance != null) {
            transform.position = PlayerController.p1instance.position + offset;
        }
    }

}
