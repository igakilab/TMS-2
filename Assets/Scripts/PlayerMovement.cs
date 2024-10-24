using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    private Vector3 right = new Vector3(3.3f,0,0);
    private Vector3 left = new Vector3(-3.3f,0,0);
    public static bool alive = true;
    void FixedUpdate(){
        if(!alive) return;

        rb =this.GetComponent<Rigidbody>();
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(this.transform.position.x < 0 ) {
                return;
            }
            rb.MovePosition(rb.position + left);
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(this.transform.position.x > 0 ) {
                return;
            }
            rb.MovePosition(rb.position + right);
        }
        Debug.Log(alive);
    }

    public void Die()
    {
        alive = false;
        // ゲームを終わらせる　シーン変更はMediaPipeがだめになるので、カメラ移動でシーン変更を再現

    }
}
