using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject timeLimit_object = null; // Textオブジェクト
    public static int timeLimit = 90;
    public GameObject scorePanel;
    float remainingTime;
    CameraFollow cameraFollow;
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Text timeLimit_text = timeLimit_object.GetComponent<Text> ();
        float remainingTime = timeLimit - Time.time;
        if (remainingTime < 0) remainingTime = 0;
        timeLimit_text .text = "残り時間：" +Mathf.FloorToInt(remainingTime).ToString();

        if( remainingTime <= 0 ){
            cameraFollow.GameClear();
            uIManager.GameClearUI();
            scorePanel.transform.position = new Vector3(0, 0,0);
        }
    }
}
