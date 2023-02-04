using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public GameObject breakParticles;
    public GameObject damageText;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 9) //Hit Ground or Wall
        {
            StartCoroutine(BreakBullet());
        }
        if (collision.gameObject.layer == 12) //Hit Enemy
        {
            StartCoroutine(BreakBullet());

            EnemyHealth eHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            eHealth.TakeDamage(damage);

            DamageText.DisplayDamageText(damage, damageText, transform.position);
        }

    }

    IEnumerator BreakBullet()
    {
        GameObject bp = Instantiate(breakParticles, transform.position, Quaternion.identity);

        MeshRenderer mr = GetComponent<MeshRenderer>();
        BoxCollider bx = GetComponent<BoxCollider>();

        mr.enabled = false;
        bx.enabled = false;

        yield return new WaitForSeconds(2);

        Destroy(bp);
        Destroy(gameObject);
    }
}
