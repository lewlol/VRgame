using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public static void DisplayDamageText(float damage, GameObject damageText, Vector3 position)
    {
        //Random Position Modifier
        float x = Random.Range(-0.2f, 0.2f);
        float z = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(0f, 0.5f);
        Vector3 offset = new Vector3(x, y, z);

        GameObject newDT = Instantiate(damageText, position + offset, Quaternion.identity);
        TextMesh tm = newDT.GetComponent<TextMesh>();
        newDT.transform.LookAt(position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        tm.text = damage.ToString();
        Destroy(newDT, 3);
    }
}
