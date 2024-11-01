using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{   
    public GameObject BreakingBallPrefab;
    public static Boolean Alive = true;
    public static Boolean Clear = false;
    public Boolean DebugPlay = true;
    public float speed = 15;

    public UDPReceive udpReceive;
    public GameObject Player;
    CameraFollow cameraFollow;
    UIManager uIManager;
    Rigidbody rb;

    private float rightx = 3.3f;
    private float leftx = -3.3f;
    private float midx = 0.0f;
    private Vector3 BallSpawnPoint = new (0,0,1.5f);//Playerの位置にSpawnさせるとバグの原因になるので少し前方に
    void Start(){
        cameraFollow = FindObjectOfType<CameraFollow>();
        uIManager = FindObjectOfType<UIManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if (!Alive) return;
        if(Clear)return; 
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    void Update()
    {
        string data = udpReceive.data;
        if(DebugPlay){
            
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                MovePlayer(leftx);
            }else if(Input.GetKeyDown(KeyCode.RightArrow)){
                MovePlayer(rightx);
            }else if(Input.GetKeyDown(KeyCode.UpArrow)){
                MovePlayer(midx);
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                Instantiate(BreakingBallPrefab,BallSpawnPoint + transform.position, Quaternion.identity);
            }
        }else{
            if (data ==  "left"){
                MovePlayer(leftx);
            }else if(data == "right"){
                MovePlayer(rightx);
            }
            else if(data == "middle"){
                MovePlayer(midx);
            }
        }
    }

    void MovePlayer(float targetX)
    {
        if (transform.position.x != targetX)
        {
            rb.MovePosition(new Vector3(targetX, transform.position.y, transform.position.z));
        }
    }

    void GameOver(){
        cameraFollow.GameOverScene();
        uIManager.GameOverUI();
    }

    public void Die(){
        Alive = false;
        Debug.Log(Alive);
        
        Invoke("GameOver",2);
    }
}
