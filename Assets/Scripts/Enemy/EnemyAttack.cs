﻿using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    [SerializeField] PlayerStats stats; // Scriptable Object
    int id_PlayerDead = Animator.StringToHash("PlayerDead");


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
            playerInRange = true;
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
            playerInRange = false;
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            Attack ();

        if(stats.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
            anim.SetTrigger (id_PlayerDead);
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(stats.currentHealth > 0)
            playerHealth.TakeDamage (attackDamage);
    }
}
