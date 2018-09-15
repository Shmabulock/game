﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour {
    public Text TimerText;
    private float myTimer;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        TimerText.gameObject.SetActive(false);
        myTimer = 0;
        DontDestroyOnLoad(this);
        if (TimerText.gameObject.activeSelf)
            TimerText = GameObject.Find("timerText").GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (TimerText != null)
        {
            if (TimerText.gameObject.activeSelf)
            {
                if (Application.loadedLevelName == "gameplay")
                {

                    myTimer += Time.deltaTime;
                    //  TimerText = GameObject.Find("timerText").GetComponent<Text>();
                    if (TimerText != null)
                        TimerText.text = myTimer.ToString("F");
                }
            }
        }
                if (Application.loadedLevelName == "gameOver")
                {
                    TimerText = GameObject.Find("score").GetComponent<Text>();
                    TimerText.text = "Your time is " + myTimer.ToString("F") + " seconds";
                }
            
        
        if(Application.loadedLevelName != "gameplay")
            Destroy(this.gameObject);
        
    }

}
