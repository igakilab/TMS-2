using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        StartPos = transform.position;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0){
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                Time.timeScale = 1;
            }
        }
        Vector3 targetPos = player.position + offset;
        targetPos.x = StartPos.x;
        targetPos.y = StartPos.y;
        transform.position = targetPos;
    }
}
