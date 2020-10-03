using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static float timeLife = 0;
    private static bool finish = true;
    private static float timeStart;
    private static bool reset = false;
    private static bool pause = true;

    private void Start()
    {
        timeStart = timeLife;

    }

    void FixedUpdate()
    {
        if (!pause)
        {
            timeLife -= Time.deltaTime;
            if (timeLife <= 0)
            {
                pause = finish = true;
            }
            if (reset)
            {
                timeLife = timeStart;
                reset = pause = finish = false;
            }
        }
    }

    public static float getTimeStart() => timeStart;
    public static bool getFinish() => finish;
    public static void Pause() => pause = true;
    public static void Initialize() => pause = false;

    public static void configTime(float mytime)
    {
        timeLife = timeStart = mytime;
        pause = true;
    }

    public static void resetTimer()
    {
        pause = false;
        reset = true;
    }

}
