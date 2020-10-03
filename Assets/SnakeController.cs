using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float velocity = 2f;
    private Rigidbody2D rb2d;

    private float limitX;
    public float distance = 5f;
    private int direction = 1;

    void FixedUpdate()
    {
        //Si el enemigo llega al limite de la distancia permitida, regresa
        if (transform.position.x > limitX) direction = -1;
        //Si el enemigo regresa a la posicion de inicio, cambia de dirección
        else if (limitX - distance > transform.position.x) direction = 1;
        Move();
    }

    void Start()
    {
        //Crea el limite de distancia que puede avanzar en el eje X
        limitX = this.transform.position.x + distance;
        //Instancia la variable de la fuerza
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Aplica la fuerza del movimiento
    private void Move()
    {
        //Formula de la velocidad (Avanzar derecha * velocidad * dirección)
        rb2d.velocity = Vector2.right * velocity * direction;
        //Invierte el sprite en el eje X
        transform.localScale = new Vector3(direction, 1f, 1f);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //Si colisionas con una Pared, el enemigo cambia de direccion de regreso
        if (collision.gameObject.name.Equals("Pared"))
        {
            direction *= -1;
            Move();
        }

    }
}
