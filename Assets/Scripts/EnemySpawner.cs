﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;

    float maxSpawnRateInSeconds = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnEnemy()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);


        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 2f)
        {

            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 2f;

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 2f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 2f)
            CancelInvoke("IncreaseSpawnRate");
    }


    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 2f;

        Invoke("SpawnEnemy", maxSpawnRateInSeconds);


        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}