using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public MeleeData stats;
    public GameObject damageText;

    Vector3 dtpos;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 12)
        {
            EnemyHealth eHealth = collision.gameObject.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(stats.damage);
            DamageText();
            dtpos = collision.gameObject.transform.position;
        }
    }

    public void DamageText()
    {
        //Random Position Modifier
        float x = Random.Range(-0.2f, 0.2f);
        float z = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(0f, 0.5f);
        Vector3 offset = new Vector3(x, y, z);

        GameObject newDT = Instantiate(damageText, dtpos + offset, Quaternion.identity);
        TextMesh tm = newDT.GetComponent<TextMesh>();
        newDT.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        tm.text = stats.damage.ToString();
        Destroy(newDT, 3);
    }
}
