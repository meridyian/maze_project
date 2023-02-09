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
    private float gameTimer ;
    public string timerString;

    

    private void Awake()
    {
        LoadPlayer();
    }

    

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        timerString = data.timeString;
    }

    
     
    void Update()
    {   
        gameTimer += Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;

        timerString =string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimerText.text = timerString;
    }
    

}
