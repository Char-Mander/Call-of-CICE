﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArmaClass
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private bool isUnlocked;

    public void enableWeapon() { weapon.SetActive(true); }

    public void disableWeapon() { weapon.SetActive(false); }

    public bool getIsUnlocked() { return isUnlocked; }

    public void setIsUnlocked(bool unlock) { isUnlocked = unlock; }
}

public class WeaponController : MonoBehaviour
{
    //Variables accesibles desde Unity
    //Armas disponibles
    [SerializeField]
    private List<ArmaClass> weaponList = new List<ArmaClass>();
    [SerializeField]
    private float changeWeaponTime;

    //Variales privadas
    private bool canChangeWeapon = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator Reload()
    {
        canChangeWeapon = false;   
        yield return new WaitForSeconds(changeWeaponTime);
        canChangeWeapon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canChangeWeapon)
        {
            DetectWeaponInput();
        }
    }

    void DetectWeaponInput()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            if( i < 9)
            {
                if (weaponList[i].getIsUnlocked())
                {
                    if (Input.GetKeyDown((i + 1).ToString()))
                    {
                        Selectweapon(i);
                        StartCoroutine(Reload());
                    }
                }
            }
        }
    }

    void Selectweapon(int weaponIndex)
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].disableWeapon();
        }
        weaponList[weaponIndex].enableWeapon();
    }

    public void UnlockWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weaponList.Count)
        {
            weaponList[weaponIndex].setIsUnlocked(true);
        }
    }
}
