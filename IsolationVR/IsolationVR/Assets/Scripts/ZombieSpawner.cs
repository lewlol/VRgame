using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public void SpawnZombie()
    {
        GameObject zomb = Instantiate(zombie, transform.position, Quaternion.identity);
    }
}
