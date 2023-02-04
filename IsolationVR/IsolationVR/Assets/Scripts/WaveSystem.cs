using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int wave;
    public int zombieCount;

    int maxZombieCount = 12;

    public GameObject[] spawnPoints;

    float currentZombies;
    float timeTillNextZombie;
    int enemyDiff;
    int totalKills;
    private void Start()
    {
        enemyDiff = 1;
        maxZombieCount = 12;
        timeTillNextZombie = Random.Range(5, 24);
    }
    private void Update()
    {
        float countDown = timeTillNextZombie -= Time.deltaTime; 
        if(countDown <= 0)
        {
            SpawnZombie();
        }
    }
    public void SpawnZombie()
    {
        if(currentZombies < maxZombieCount)
        {
            int zombiesToSpawn = Random.Range(1, 5);
            for(int i = 0; i < zombiesToSpawn; i++)
            {
                StartCoroutine(SpawningZombie());
            }
        }
        timeTillNextZombie = Random.Range(5, 24);
    }
    public void ZombieDied()
    {
        currentZombies--;
        totalKills++;
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
