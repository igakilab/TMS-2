using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static int totalScore = 0;
    //public static int clearScore = 100;
    public GameObject score_object = null; // Textオブジェクト


    public static void addScore(int getscore){
        totalScore = getscore + totalScore;
        Debug.Log(totalScore);
        /*if(totalScore >= clearScore){
            totalScore = clearScore;
            return;
        }*/


    }

    private void Start() {
    }

    private void Update() {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = "スコア：" + totalScore;
    }
}