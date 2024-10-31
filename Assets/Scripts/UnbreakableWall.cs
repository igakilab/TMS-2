using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableWall : Wall
{
    void Start()
    {
        
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            ScoreManager.addScore(score);
            Destroy(gameObject);
            
        }else if(collision.gameObject.name == "BreakingBall(clone)"){
            score++;
        }
    }

    void Update()
    {
        
    }
}
