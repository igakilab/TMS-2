using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject wallPrefab;
    public GameObject BwallPrefab;
    public int wallHarddistance = 6;//破壊可能壁と壊れない壁が同時に出てくるポイントの間隔
    public int wallrandomdistance = 2;//破壊可能壁と壊れない壁のどちらか１つがランダムに湧く間隔　
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

    public bool GetRandomBoolean()
    {
        return Random.value > 0.5f; // 0.5より大きければtrue、そうでなければfalse
    }

    private void Update()
    {
        
    }
    
    void SpawnWall()
    {   
        if(GroundSpawner.tileIndex % wallrandomdistance != 0 && GroundSpawner.tileIndex % wallHarddistance != 0)return;
        if(GroundSpawner.FirstSpawntile - GroundSpawner.tileIndex >= 0)return;
        int bWallSpawnIndex = wallSPointList[Random.Range(0,wallSPointList.Count)];
        if(GroundSpawner.tileIndex % wallHarddistance == 0){
            
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
        }else if(GroundSpawner.tileIndex % wallrandomdistance == 0){
            Transform spawnPoint = transform.GetChild(bWallSpawnIndex).transform;
            if(GetRandomBoolean()){
                Instantiate(wallPrefab, spawnPoint.position,Quaternion.identity,transform);
            }else{
                Instantiate(BwallPrefab, spawnPoint.position,Quaternion.identity,transform);
            }
        }
    }
}
