using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoPuente : MonoBehaviour
{
    private int cont = 0;

    private void Start()
    {
        GetComponent<Renderer>().sortingOrder = -32768;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            cont++;
        }
    }

    private void Update()
    {
        if (cont > 1)
        {
            Debug.Log("Mostrar Puente");
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = -32768;
        }
    }
}
