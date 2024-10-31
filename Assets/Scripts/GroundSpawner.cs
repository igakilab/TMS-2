using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public static int tileIndex = 0;
    public static int FirstSpawntile = 10;  
    Vector3 nextSpawnPoint;
    public void SpawnTile()
    {   
        tileIndex++;  
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    private void Start()
    {
        nextSpawnPoint = groundTile.transform.position;
        for(int i = 0; i < FirstSpawntile; i++){
            SpawnTile();
        }
    }
}
