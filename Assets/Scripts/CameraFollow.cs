using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 StartPos;
    PlayerMovement playerMovement;
    void Start()
    {
        offset = transform.position - player.position;
        StartPos = transform.position;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>(); 
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0){
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                Time.timeScale = 1;
            }
        }
        if(!PlayerMovement.alive){
            transform.position = StartPos;
            transform.rotation = Quaternion.Euler(0,180,0);
        }else{
            Vector3 targetPos = player.position + offset;
            targetPos.x = StartPos.x;
            targetPos.y = StartPos.y;
            transform.position = targetPos;
        }
    }
}
