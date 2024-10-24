using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public UDPReceive udpReceive;
    public GameObject Player;
    private Rigidbody rb;
    private Vector3 right = new Vector3(3.3f,0,0);
    private Vector3 left = new Vector3(-3.3f,0,0);
    private Vector3 mid = new Vector3(0, 0, 0);
    void FixedUpdate(){
        rb =this.GetComponent<Rigidbody>();
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        if (data ==  "left"){
            if(this.transform.position.x < 0 ) {
                return;
            }
            transform.position = new Vector3(-3.3f, transform.position.y, transform.position.z);
        }else if(data == "right"){
            if(this.transform.position.x > 0 ) {
                return;
            }
            transform.position = new Vector3(3.3f, transform.position.y, transform.position.z);
        }
        else if(data == "middle"){
            if (this.transform.position.x == 0)
            {
                return;
            }
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

    }
}
