using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemsPrefabs;
    private float spawnRangeX = 10.2F; // Rango de spawn en el eje x.
    private float startDelay = 2F;
    private float spawnInterval = 3F;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomItems", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomItems() 
    {
        int itemIndex = UnityEngine.Random.Range(0, itemsPrefabs.Length); // Genero un número al azar entre o y el largo del arreglo.
        Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 5.22F); // Limites en donde spwnearan los items.
        Instantiate(itemsPrefabs[itemIndex],spawnPos, itemsPrefabs[itemIndex].transform.rotation); // Generamos los itemes aleatoriamente.
    }
}
