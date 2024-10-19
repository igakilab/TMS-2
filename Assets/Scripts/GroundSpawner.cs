using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    [System.NonSerialized] public int tileIndex = 0;  
    Vector3 nextSpawnPoint;
    public void SpawnTile()
    {   
        tileIndex++;  
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    private void Start()
    {
        for(int i = 0; i < 10;i++){
            SpawnTile();
        }
    }
}
