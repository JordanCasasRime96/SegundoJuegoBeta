using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMessage : MonoBehaviour
{
    public float myTime;
    public GameObject player1;

    void Start()
    {
        Timer.configTime(myTime);
        this.gameObject.transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.getFinish())
        {
            this.gameObject.transform.localScale = new Vector2(0, 0);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector2(1, 1);
            if (player1.transform.position.x > transform.position.x)
                transform.localScale = new Vector2(1, 1);
            else transform.localScale = new Vector2(-1, 1);
        }
        
    }

    public static void viewText()
    {
        Timer.resetTimer();
    }
}
