using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("XuanTien/AmmoBox")]
public class AmmoBox : MonoBehaviour
{
    public int amountAmo = 200;
    public enum AmmoType
    {
        RifeAmmo,
        PistolAmmo
    }
    public AmmoType amoType;
}
