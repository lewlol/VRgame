using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject[] guns;

    private void Start()
    {
        int ranGun = Random.Range(0, guns.Length);
        Instantiate(guns[ranGun], transform.position, new Quaternion(0, 0, 90, 0));
    }
}
