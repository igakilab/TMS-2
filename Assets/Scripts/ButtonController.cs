using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    GameObject parent;

    void Start()
    {   
        parent = this.transform.parent.gameObject;

    }

    public void OnClick(){
        GameStart();
    }

    public void GameStart()
    {
        parent.SetActive(false);
        Time.timeScale = 1;
    }
}
