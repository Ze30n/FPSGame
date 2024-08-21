using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("XuanTien/GameReferences")]
public class GameReferences : MonoBehaviour
{ 
    public static GameReferences Instance
    {
        get => instance;
    }
    private static GameReferences instance;
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
    }

    public GameObject bulletEffectImpactPrefabs;
    public GameObject bloodEffectImpactPrefabs;
    
}
