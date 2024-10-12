using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    private Rigidbody rb;
    private Vector3 right = new Vector3(3.3f,0,0);
    private Vector3 left = new Vector3(-3.3f,0,0);  
    void FixedUpdate(){
        rb =this.GetComponent<Rigidbody>();
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    // Update is called once per frame
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

    }
}
