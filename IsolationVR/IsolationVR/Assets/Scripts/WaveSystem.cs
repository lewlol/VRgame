using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int wave;
    public int zombieCount;

    int maxZombieCount = 24;

    public GameObject[] spawnPoints;

    float currentZombies;
    private void Start()
    {
        StartCoroutine(MidRound(10));
    }
    public void GenerateWave()
    {
        //Determine Zombie Count
        zombieCount = 5 + wave;
        if(zombieCount > maxZombieCount)
        {
            zombieCount = maxZombieCount;
        }

        //Spawn a Zombie at a random Location
        for(int x = 0; x < zombieCount; x++)
        {
            StartCoroutine(SpawningZombie());
        }
    }

    //Zombie Dies and Check for Next Round
    public void ZombieDied()
    {
        currentZombies--;
        if (currentZombies <= 0)
        {
            StartCoroutine(MidRound(15));
        }
    }

    //Mid Round Waiting 
    IEnumerator MidRound(float time)
    {
        //Reset Zombie Count
        currentZombies = 0;
        yield return new WaitForSeconds(time);

        //Generate New Wave
        wave++;
        GenerateWave();
    }

    //Spawning Zombies with an offset so that they all done look exactly the same when walking
    IEnumerator SpawningZombie()
    {
        float waitTimer = Random.Range(0, 5);
        yield return new WaitForSeconds(waitTimer);
        int sp = Random.Range(0, spawnPoints.Length);
        spawnPoints[sp].GetComponent<ZombieSpawner>().SpawnZombie();
        currentZombies++;
    }
}
