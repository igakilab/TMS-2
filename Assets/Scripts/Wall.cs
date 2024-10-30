using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    protected PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    protected virtual void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player"){
            playerMovement.Die();
        }
    }
    void Update()
    {
        
    }
}
