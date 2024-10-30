using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject wallPrefab;
    public int walldistance = 3;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnWall();
    }

    private void OnTriggerExit(Collider collision)
    {   
        if(collision.gameObject.name == "Player"){
            groundSpawner.SpawnTile();
            Destroy(gameObject,2);
        }
    }

    private void Update()
    {
        
    }
    
    void SpawnWall()
    {
        int wallSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(wallSpawnIndex).transform;
        if(GroundSpawner.tileIndex % walldistance == 0){
            Instantiate(wallPrefab, spawnPoint.position,Quaternion.identity,transform);
        }
    }
}
