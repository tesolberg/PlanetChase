using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public Enemy dweller;
    public float maxWaveSize;
    [Range(0,100)]
    public float waveDeviation;
    public float waveInterval;
    public float growthFactor;
    public float growthInterval;

    private float waveTimer;

    private void Start() {
        StartCoroutine("RunHive");
        StartCoroutine("RunGrowth");
    }

    IEnumerator RunHive() {
        while (true) {
            float thisInterval = Random.Range(waveInterval - waveInterval * 0.2f, waveInterval + waveInterval * 0.2f);
            yield return new WaitForSeconds(thisInterval);

            int thisWave = (int)Random.Range(maxWaveSize - maxWaveSize * waveDeviation / 100, maxWaveSize + 1);
            Debug.Log("Wave size: " + thisWave);
            for (int i = 0; i < thisWave; i++) {
                Instantiate(dweller, transform.position, Quaternion.identity, transform);
            }
        }
    }

    IEnumerator RunGrowth() {
        while (true) {
            yield return new WaitForSeconds(growthInterval);
            maxWaveSize *= growthFactor;
        }
    }

}
