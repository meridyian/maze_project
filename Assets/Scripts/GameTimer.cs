using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour, IDataPersistence
{
    public Text gameTimerText;
    private float gameTimer ;
    private string timerString;

    // Update is called once per frame

    private void Start()
    {
        gameTimer = 0f;
    }

    public void LoadData(GameData data)
    {
        this.timerString = data.timerString;
    }

    public void SaveData(ref GameData data)
    {
        data.timerString = this.timerString;
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
