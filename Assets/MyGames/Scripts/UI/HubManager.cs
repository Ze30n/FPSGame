using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("XuanTien/HubManager")]
public class HubManager : MonoBehaviour
{
    public HubManager Instance
    {
        get => instance;
    }

    private static HubManager instance;
    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
    }

    [Header("Public UI")]
    public TextMeshProUGUI magazineAmmoUI;
    public TextMeshProUGUI totalAmmoUI;
    public Image ammoTypeUI;
    public Image activeWeaponUI;
    public Image unActiveWeaponUI;  
    
    void Update()
    {
        // Lay vu khi da active
        Weapon activeWeapon = WeaponManager.Instance.activeWeaponSlot.transform.GetChild(0).GetComponent<Weapon>();
        // Lay vu khi chua active
        Weapon unactiveWeapon = GetUnActiveWeaponSlot().GetComponentInChildren<Weapon>();
        //
        Weapon.WeaponModel model = activeWeapon.thisWeaponModel;
        magazineAmmoUI.text = $"{activeWeapon.bulletLeft}";
        totalAmmoUI.text = $"{WeaponManager.Instance.CheckAmmoLeftFor(model)}";
        activeWeaponUI.sprite = GetWeaponSprite(model);
        ammoTypeUI.sprite = GetAmoSprite(model);
        //
        if (activeWeapon != null)
        {
            
            unActiveWeaponUI.sprite = GetWeaponSprite(unactiveWeapon.thisWeaponModel);
        }
    }

    private GameObject GetUnActiveWeaponSlot()
    {
        foreach (var item in WeaponManager.Instance.weaponSlot)
        {
            if (item != WeaponManager.Instance.activeWeaponSlot)
            {
                return item;
            }
        }
        return null;
    }
    private Sprite GetWeaponSprite(Weapon.WeaponModel model)
    {
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                return Resources.Load<GameObject>("PistolWeapon").GetComponent<SpriteRenderer>().sprite;
            case Weapon.WeaponModel.M16:
                return Resources.Load<GameObject>("M16Weapon").GetComponent<SpriteRenderer>().sprite;
            default:
                return null;
        }
    }
    private Sprite GetAmoSprite(Weapon.WeaponModel model)
    {
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                return Resources.Load<GameObject>("PistolAmmo").GetComponent<SpriteRenderer>().sprite;
            case Weapon.WeaponModel.M16:
                return Resources.Load<GameObject>("M16Ammo").GetComponent<SpriteRenderer>().sprite;
            default:
                return null;
        }
    }
}
