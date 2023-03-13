using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
   
    public Text gameTimerText;
    public float gameTimer =0f;
    public float timerString;

    // Game timer should be started as deactive and activated in game manager when player is spawned
    
     
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
