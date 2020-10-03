using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swichts : MonoBehaviour
{

    private bool activate;

    void FixedUpdate()
    {
        //Debug.Log(activate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Solid"))
        {
            activate = true;
        }
        else
        {
            activate = false;
        }
    }
}
