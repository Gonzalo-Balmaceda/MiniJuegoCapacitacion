using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject[] itemsPrefabs;
    public GameObject[] clockPrefab;
    private float spawnRangeX = 10.2F; // Rango de spawn en el eje x.
    private float startDelay = 3F;
    private float spawnInterval = .6F;
    private float spawnIntervalClock = 30F;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomItems", startDelay, spawnInterval);
        InvokeRepeating("WaitForSpawnClock", startDelay, spawnIntervalClock);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomItems()
    {
        if (playerControllerScript.gameOver == false)
        {
            int itemIndex = UnityEngine.Random.Range(0, itemsPrefabs.Length); // Genero un número al azar entre o y el largo del arreglo.
            Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 5.22F); // Limites en donde spwnearan los items.
            Instantiate(itemsPrefabs[itemIndex], spawnPos, itemsPrefabs[itemIndex].transform.rotation); // Generamos los itemes aleatoriamente. 
        }
    }

    void WaitForSpawnClock()
    {
        int itemIndex = 0;
        Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 5.22F); // Limites en donde spwnearan los items.
        Instantiate(clockPrefab[itemIndex], spawnPos, clockPrefab[itemIndex].transform.rotation); // Generamos los itemes aleatoriamente. 
    }
}
