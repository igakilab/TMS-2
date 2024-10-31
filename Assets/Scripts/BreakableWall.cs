using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BreakableWall : Wall
{
    public int HP = 1; // 壁の耐久力

    private void Start() {
        Debug.Log("score1:"+score);
        score = HP+1;
        Debug.Log("HP"+HP);
        Debug.Log("score2"+score);
    }

    private void Update() {  
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); // Wallクラスの衝突処理も実行

        // 壁がプレイヤー以外のオブジェクトと衝突したときに耐久力を減らす
        if (collision.gameObject.name != "BrealingBall(clone)")
        {
            HP--;
            Debug.Log("Wall HP: " + HP);
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject); // HPが0になったら壁を破壊
            ScoreManager.addScore(score);
        } 
    }
}