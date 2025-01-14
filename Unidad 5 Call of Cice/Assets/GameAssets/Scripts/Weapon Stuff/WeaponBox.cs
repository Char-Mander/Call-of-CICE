﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField]
    private int numWeapon;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<WeaponController>().UnlockWeapon(numWeapon);
            Destroy(this.gameObject);
        }
    }

}
