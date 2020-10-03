using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonController : MonoBehaviour
{

    public GameObject player1;

    void Start()
    {
        
    }

    void Update()
    {
        if (player1.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(1, 1);
        else transform.localScale = new Vector2(-1, 1);
    }
}
