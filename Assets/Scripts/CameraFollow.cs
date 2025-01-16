using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public GameObject GameClearPanel;
    public GameObject GameOverPanel;
    Vector3 offset;
    Vector3 StartPos;
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        offset = transform.position - player.position;
        StartPos = transform.position;
    }

    public void GameOverScene()
    {
        GameOverPanel.SetActive(true);
    }

    public void GameClear()
    {   
        PlayerMovement.Clear =true;
        GameClearPanel.SetActive(true);
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
