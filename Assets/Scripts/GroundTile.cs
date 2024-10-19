using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject wallPrefab;
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnWall();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject,2);
    }
    private void Update()
    {
        
    }

    void SpawnWall()
    {
        int wallSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(wallSpawnIndex).transform;

        Instantiate(wallPrefab, spawnPoint.position,Quaternion.identity,transform);
    }
}
