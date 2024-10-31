using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 StartPos;
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        offset = transform.position - player.position;
        StartPos = transform.position;
        Time.timeScale = 0;
    }

    public void GameOverScene()
    {
        transform.position = StartPos;
        transform.rotation = Quaternion.Euler(0,180,0);
    }

    public void GameClear()
    {   
        PlayerMovement.Clear =true;
        Vector3 ClearPos = StartPos + new Vector3(0,0,-20);
        transform.position = ClearPos;
        transform.rotation = Quaternion.Euler(0,180,0);
    }

    void Update()
    {
        if (Time.timeScale == 0){
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                Time.timeScale = 1;
            }
        }
        if(PlayerMovement.Alive){
            Vector3 targetPos = player.position + offset;
            targetPos.x = StartPos.x;
            targetPos.y = StartPos.y;
            transform.position = targetPos;
        }
    }
}
