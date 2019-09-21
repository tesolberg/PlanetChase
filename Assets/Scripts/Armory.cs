using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{
    #region Singleton
    public static Armory instance;

    void InitSingleton() {
        if (instance != null) {
            Debug.LogError("More than one Armory detected");
        }
        else {
            instance = this;
        }
    }
    #endregion

    public Turret turretPrefab;
    public Transform unitParent_;
    public Transform gate;

    public List<Turret> turrets;


    void Start() {
        InitSingleton();
        turrets = new List<Turret>();
    }

    public void CreateTurret() {
        turrets.Add(Instantiate(turretPrefab, gate.position, Quaternion.identity, unitParent_));
    }
}
