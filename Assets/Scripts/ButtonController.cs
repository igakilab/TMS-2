using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject StartButton;
    void Start()
    {   }


    public void GameStart()
    {
        StartPanel.SetActive(false);
        StartButton.SetActive(false);
        Time.timeScale = 1;
    }
}
