using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("XuanTien/DamageHand")]
public class DamageHand : MonoBehaviour
{ public float addFore = 100;
    public float damageHand = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageble damageble = other.GetComponent<IDamageble>();
            if (damageble != null)
            {
                damageble.TakeDamage(damageHand);  
            }
        }
    }
}
