using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static int totalScore = 0;
    public GameObject score_object = null;

    public static void addScore(int getscore){
        totalScore = getscore + totalScore;
        Debug.Log(totalScore);
    }

    private void Start() {
    }

    private void Update() {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = "スコア:" + totalScore;
    }
}