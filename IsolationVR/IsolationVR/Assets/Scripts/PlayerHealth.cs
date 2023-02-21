using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    float maxHealth = 5;
    float invTime = 1;
    bool invincible;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            health -= damage;
            if (health <= 0)
            {
                //Death
                Debug.Log("Dead");
                return;
            }
            StartCoroutine(HitFrameCount());
        }
    }

    IEnumerator HitFrameCount()
    {
        invincible = true;
        yield return new WaitForSeconds(invTime);
        invincible = false;
    }
}
