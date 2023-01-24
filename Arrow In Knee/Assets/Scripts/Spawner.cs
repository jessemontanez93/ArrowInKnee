using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;
    private float timeSpawn;
    public float startSpawnTime;
    public float minTimeBetweenSpawns;
    public float decrease;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(timeSpawn <= 0)
            {
                //Spawn Hazard
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                if(startSpawnTime > minTimeBetweenSpawns)
                {
                    startSpawnTime -= decrease;
                }
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);
                timeSpawn = startSpawnTime;
            }
            else
            {
                timeSpawn -= Time.deltaTime;
            }
        }
    }
}
