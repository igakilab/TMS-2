using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScoreAdder : MonoBehaviour
{
    public int score = 1;
    void Start()
    {
        Debug.Log("WallsAdder");
    }

    private void OnTriggerExit(Collider collision) {
        Debug.Log("WallsAdder2");
        if(collision.gameObject.name  != "Player")return;
        Debug.Log("score:" + score);
        Debug.Log("collision:" + collision.gameObject.name);
        ScoreManager.addScore(score);
        Debug.Log("WallsAdder3");
    }
    void Update()
    {
        
    }
}
