using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static int totalScore = 0;
    public int clearScore = 100;
    public GameObject score_object = null;
    CameraFollow cameraFollow;
    UIManager uIManager;

    public static void addScore(int getscore){
        totalScore = getscore + totalScore;
        Debug.Log(totalScore);
    }

    private void Start() {
        cameraFollow = FindObjectOfType<CameraFollow>();
        uIManager = FindObjectOfType<UIManager>();
    }

    private void Update() {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = "スコア:" + totalScore + "/" + clearScore;
        if(clearScore == totalScore){
            cameraFollow.GameClear();
            uIManager.GameClearUI();
        }
    }
}