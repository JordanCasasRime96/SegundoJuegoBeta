using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateController : MonoBehaviour
{
    public float velocity = 1f;
    private Rigidbody2D rb2d;
    private float formula;

    public float vision = 5f;
    private float direction = -1f;
    public float angle = 60f; //No utilizar angulos de 90° o mayor.
    private float myPositionX;
    private float myPositionY;

    public GameObject player;
    private float positionPlayerX;
    private float positionPlayerY;
    private float aTan; //ArcoTangente

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Convertir el angulo usando PI y dividiendo la mitad
        angle = angle * Mathf.PI / 360;
    }

    private void Awake()
    {
        //Captura el objeto Player1

    }

    void FixedUpdate()
    {
        //Captura la posicion del jugador en eje X, Y
        positionPlayerX = player.transform.position.x;
        positionPlayerY = player.transform.position.y;
        //Capturo la posicion actual del enemigo
        myPositionX = transform.position.x;
        myPositionY = transform.position.y;
        //Formula de la cirunferencia
        formula = Mathf.Pow(Mathf.Pow(positionPlayerX - myPositionX, 2f) + Mathf.Pow(positionPlayerY - myPositionY, 2f), 0.5f);
        //Si el jugador está dentro de la cincunferencia(campo de visión)
        if (formula <= vision) {
            //Capturo el ángulo formado (teniendo en cuenta si el objetivo está en el IV cuadrante aplicando VALOR ABSOLUTO) entre el jugador y enemigo
            aTan = Mathf.Atan(Mathf.Abs((positionPlayerY - myPositionY) / (positionPlayerX - myPositionX)));
            //Verifico que el angulo del ArcoTangente es menor del angulo(significa que está dentro del ángulo de visión)
            if (aTan < angle)
            {
                //Verifico si esta mirando a la derecha
                if (direction > 0)
                {
                    //Si el jugador se encuentra al lado derecho del enemigo (solo si miras a la derecha)
                    if (positionPlayerX >= myPositionX)
                    {
                        //Perseguir al jugador
                        Follow();
                    }
                }
                //Si el enemirgo no está mirando a la derecha entonces jugador debe estar a la izquierda
                else if (positionPlayerX <= myPositionX)
                {
                    //Perseguir al jugador
                    Follow();
                }
            }
            else
                frenar();
        }
    }

    //Aplica la fuerza del movimiento
    private void Move()
    {
        //Formula de la velocidad (Avanzar derecha * velocidad * dirección)
        //rb2d.velocity = Vector2.right * velocity * direction;
        //Invierte el sprite en el eje X
        transform.localScale = new Vector3(direction, 1f, 1f);
    }

    private void Follow()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((player.transform.position.x - transform.position.x)/2, player.transform.position.y - transform.position.y) * 3f;

    }

    private void frenar()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * 0f;
    }

}
