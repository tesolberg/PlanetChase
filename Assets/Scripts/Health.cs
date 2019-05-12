﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoints;

    public void Hit(int damage) {
        hitPoints -= damage;

        if (hitPoints <= 0) {
            gameObject.SetActive(false);
        }
    }
}
