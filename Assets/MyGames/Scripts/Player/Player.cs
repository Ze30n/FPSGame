using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[AddComponentMenu("XuanTien/Player")]
public class Player : MonoBehaviour,IDamageble
{
    public float maxHealth = 100;
    public float currentHealth;

    public GameObject bloodUI;
    private Animator anim;

    public bool isPlayerDead = false;
    private int IsPlayerDeadId;

    private PlayerMovement playerMovement;
    private MouseMovement mouseMovement;

    public Slider healthSlider;
    public UnityEvent onHealthChanged;

    public float delayTime = 5;
    public float respawnTime = 1;
    public Transform spawnPoint;

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0)
        {          
            PlayerDead();
        }
        StartCoroutine(BloodHub());
        UpdateHealthUI();
    }
     IEnumerator BloodHub()
    {
        bloodUI.SetActive(true);
        yield return new WaitForSeconds(1);
        bloodUI.SetActive(false);
    }
    private void PlayerDead()
    {
        anim.SetTrigger(IsPlayerDeadId);
        playerMovement.enabled = false;
        mouseMovement.enabled = false;
        isPlayerDead = true;

        StartCoroutine(DeadTime());
        //gameObject.SetActive(false);    
    }

    IEnumerator DeadTime()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
        Invoke("Respawn", respawnTime);
    }
    void Respawn()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
        currentHealth = maxHealth;
        UpdateHealthUI();

        gameObject.SetActive(true);

        playerMovement.enabled = true;
        mouseMovement.enabled = true;
        isPlayerDead = false;
    }
    void Start()
    {
        currentHealth = maxHealth;
        IsPlayerDeadId = Animator.StringToHash("IsPlayerDead");
        anim = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        mouseMovement = GetComponent<MouseMovement>();
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
            onHealthChanged.Invoke();
        }
    }
}
