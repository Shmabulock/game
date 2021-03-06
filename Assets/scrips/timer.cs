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
                if (SceneManager.GetActiveScene().name == SCENE_NAMES.Gameplay)
                {

                    myTimer += Time.deltaTime;
                    //  TimerText = GameObject.Find("timerText").GetComponent<Text>();
                    if (TimerText != null)
                        TimerText.text = myTimer.ToString("F");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == SCENE_NAMES.GameOver)
        {
            TimerText = GameObject.Find("score").GetComponent<Text>();
            if (!PlayerPrefs.HasKey(KEYMANAGER.HIGHSCORE))
                PlayerPrefs.SetFloat(KEYMANAGER.HIGHSCORE, myTimer);
            if(PlayerPrefs.GetFloat(KEYMANAGER.HIGHSCORE) < myTimer)
                PlayerPrefs.SetFloat(KEYMANAGER.HIGHSCORE, myTimer);
            PlayerPrefs.Save();

            TimerText.text = "Highscore: " + PlayerPrefs.GetFloat(KEYMANAGER.HIGHSCORE).ToString("F") + "\n" + "Your time is: " + myTimer.ToString("F");
        }
            
        
        if(SceneManager.GetActiveScene().name != SCENE_NAMES.Gameplay)
            Destroy(this.gameObject);
        
    }

}
