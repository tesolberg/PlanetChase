using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overseer : MonoBehaviour {

    #region Singleton
    public static Overseer instance;

    void InitSingleton() {
        if (instance != null) {
            Debug.LogError("More than one Overseer detected");
        }
        else {
            instance = this;
        }
    }
    #endregion

    public Armory armory;

}
