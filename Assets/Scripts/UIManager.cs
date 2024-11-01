using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas canvas;
    GameObject gameOverImage;
    GameObject gameClearImage;
    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        gameOverImage = canvas.transform.GetChild(2).gameObject;
        gameClearImage = canvas.transform.GetChild(3).gameObject;
        gameOverImage.SetActive(false);
        gameClearImage.SetActive(false);
        Time.timeScale = 0;
    }

    void Update()
    {
        
    }

    public void GameOverUI(){
        gameOverImage.SetActive(true);
    }

    public void GameClearUI(){
        gameClearImage.SetActive(true);
    }
}
