using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private void Start() {
        StartCoroutine("TestRoutine");
    }

    IEnumerator TestRoutine() {
        yield return new WaitForSeconds(0.1f);

        Armory.instance.CreateTurret();
        Armory.instance.CreateTurret();

        yield return new WaitForSeconds(0.1f);

        Armory.instance.turrets[0].Deploy(new Vector3(-2f, 0f, -12f));
        Armory.instance.turrets[1].Deploy(new Vector3(-1f, 0f, 0f));
    }



}
