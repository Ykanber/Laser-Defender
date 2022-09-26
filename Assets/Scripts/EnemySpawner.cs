using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 5f;
    WaveConfigSO currentWave;

    bool isLooping = true;
    
    public WaveConfigSO CurrentWave { get => currentWave;}




    void Start()
    {
        StartCoroutine(nameof(SpawnWaves));   
    }

    private IEnumerator SpawnWaves()
    {
        do
        {
            foreach (var config in waveConfigs)
            {
                currentWave = config;
                StartCoroutine(nameof(SpawnEnemies));
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        } while (isLooping);
        
    }

    private IEnumerator SpawnEnemies()
    {

        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0,0,180), transform);
            yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
        }
    }
}
