using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int score;
    public float targetTime = 30.0f;
    bool timer = true;
    void Update()
    {
        Timer();
        /*targetTime -= Time.deltaTime;

        if (timer = false & targetTime <= 0.0f)
        {
            timerEnded();
        }
        */

    }

    void timerEnded()
    {
        
        print("Timer End");
    }

    void Timer()
    {
        if (timer == true)
        {
            targetTime -= Time.deltaTime;
        }
        if (targetTime <= 0.0f)
        {
            timer = false;
            timerEnded();
        }
    }
}

