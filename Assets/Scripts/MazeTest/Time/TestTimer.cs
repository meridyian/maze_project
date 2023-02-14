using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTimer : MonoBehaviour
{
    public Text gameTimerText;
    public float gameTimer =0f;
    public float timerString;
    
    private void Awake()
    {
        // since you call loadplayer on awake timer will not start from 0
        LoadPlayer();
    }
    
    public void LoadPlayer()
    {
        // get the time that you left earlier from PlayerData
        // update the string
        
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
