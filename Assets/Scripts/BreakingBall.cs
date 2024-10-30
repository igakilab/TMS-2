using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BreakingBall : MonoBehaviour
{   
    public float speed = 60f;
    void Start()
    {
        Destroy(gameObject,2);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Wall(Clone)"){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void Update()
    {
    }
}
