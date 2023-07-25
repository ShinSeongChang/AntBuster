using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject mobPrefab;

    private float lastSpawn = default;
    private float spawnTime = default;

    private float spawnMin = 300.0f;
    private float spawnMax = 600.0f;


    // Start is called before the first frame update
    void Start()
    {
        lastSpawn = 0f;
        spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {


        if (lastSpawn <= Time.time)
        {
            Instantiate(mobPrefab);
            spawnTime = Random.Range(spawnMin, spawnMax);
            lastSpawn += spawnTime;
            
        }

    }
}
