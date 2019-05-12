using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start() {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

}
