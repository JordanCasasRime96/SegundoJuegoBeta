using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject player1;
    //private float Power = 2f;

    private void Start()
    {
        Timer.configTime(2f);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.CompareTag("Player"))
        //Debug.Log(collision.gameObject.name
        if (collision.gameObject.name.Equals("Player1"))
        {
            player1.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
            Timer.resetTimer();
        }
        if (Timer.getFinish())
        {
            player1.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (collision.gameObject.tag.Equals("Grabbable"))
        {
            Destroy(gameObject);
        }
    }
}
