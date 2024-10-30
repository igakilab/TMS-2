using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject wallPrefab;
    public GameObject BwallPrefab;
    public int walldistance = 3;
    private List<int> wallSPointList = new List<int> {2,3,4};

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
        if(GroundSpawner.tileIndex % walldistance != 0)return;

        int bWallSpawnIndex = wallSPointList[Random.Range(0,wallSPointList.Count)];

        foreach (int index in wallSPointList)
        {
            Transform spawnPoint = transform.GetChild(index).transform;
            if (index == bWallSpawnIndex)
            {
                // 壊れる壁をスポーン
                Instantiate(BwallPrefab, spawnPoint.position,Quaternion.identity,transform);
            }
            else
            {
                // 壊れない壁をスポーン
                Instantiate(wallPrefab, spawnPoint.position,Quaternion.identity,transform);
            }
        }
    }
}
