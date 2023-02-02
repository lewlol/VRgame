using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float damage;

    float maxHealth;
    Rigidbody rb;

    private void Awake()
    {
        maxHealth = 7f; //maxHealth = currentRound * 1.5;
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            WaveSystem ws = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSystem>();
            ws.ZombieDied();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
