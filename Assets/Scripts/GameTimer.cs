using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text gameTimerText;
    public float gameTimer =0f;
    public float timerString;

    

    private void Awake()
    {
        LoadPlayer();
    }

    

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        timerString = data.timeString;
        gameTimer = timerString;
    }

    
     
    void Update()
    {
        gameTimer += Time.deltaTime;
        timerString = (int)gameTimer;
        
        
        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

       
        gameTimerText.text = "Time: " + string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        
    }
    

}
