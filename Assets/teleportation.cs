using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool left;
    public bool rigth;

    private void Awake()
    {
        //Nos aseguramos de que target se ha establecido o lanzaremos except

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))

    }
}
