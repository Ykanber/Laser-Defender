using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.CurrentWave;
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveSpeed = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        if(waypointIndex == waypoints.Count)
        {
            Destroy(gameObject);
        }
    }
}
