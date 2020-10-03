using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonController : MonoBehaviour
{
    public float vision = 5f;
    private float direction = 1f;
    private float formula;

    Animator anim;
    Rigidbody2D rb2d;
    private float myPositionX;
    private float myPositionY;
    private float angle = Mathf.PI / 8;

    private bool left;
    private bool up;
    private bool diagonal;
    private bool die;

    public GameObject player;
    //private const string Tag = "Player";
    private float positionPlayerX;
    private float positionPlayerY;
    private float aTan; //ArcoTangente

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //Establezco las variables del animator con las variables declaradas

        //Capturo la posicion del cañon
        myPositionX = transform.position.x;
        myPositionY = transform.position.y;
    }

    /*private void Awake()
    {
        //Captura el objeto Player1
        player = GameObject.FindGameObjectWithTag(Tag);
    }*/

    void FixedUpdate()
    {
        if (!die)
        {
            //Captura la posicion del jugador en eje X, Y
            positionPlayerX = player.transform.position.x;
            positionPlayerY = player.transform.position.y;
            formula = Mathf.Pow(Mathf.Pow(positionPlayerX - myPositionX, 2f) + Mathf.Pow(positionPlayerY - myPositionY, 2f), 0.5f);
            //Debug.Log(formula);
            if (formula <= vision)
            {
                //Capturo el ángulo formado entre el jugador y enemigo
                aTan = Mathf.Atan((positionPlayerY - myPositionY) / (positionPlayerX - myPositionX));
                //Si el Jugador está a la izquierda
                //Debug.Log(aTan * 180 / Mathf.PI);
                if (positionPlayerX <= myPositionX)
                {
                    direction = 1; //Mirando a la izquierda
                                   //Si el Jugador está arriba
                    if (positionPlayerY >= myPositionY)
                    {
                        if (-aTan > angle * 3)
                        {
                            up = true;
                            left = false;
                            diagonal = false;
                            //Mira solo arriba
                            //Debug.Log("Arriba");
                        }
                        else if (-aTan > angle)
                        {
                            //Mira Izquierda y Arriba (diagonal)
                            up = true;
                            left = true;
                            diagonal = true;
                            //Debug.Log("Diagonal: Arriba y derecha");
                        }
                        else
                        {
                            left = true;
                            up = false;
                            diagonal = false;
                            //Mira solamente a la izquierda
                            //Debug.Log("Izquierda");
                        }
                    }
                    //Si el jugador está abajo
                    else
                    {
                        if (aTan < angle)
                        {
                            left = true;
                            up = false;
                            diagonal = false;
                            //Mira solamente a la izquierda
                            //Debug.Log("Izquierda");
                        }
                        else if (aTan < angle * 3)
                        {
                            //Mira Izquierda y Abajo (diagonal)
                            left = true;
                            diagonal = true;
                            up = false;
                            //Debug.Log("Diagonal: Abajo e Izquierda");
                        }
                        else
                        {
                            //Mira Abajo
                            left = false;
                            up = false;
                            diagonal = false;
                            //Debug.Log("Abajo");
                        }
                    }
                }
                //Si el jugador está a la derecha
                else
                {
                    direction = -1; //Mirando a la derecha;
                                    //Si el Jugador está abajo (CUARTO CUADRANTE)
                    if (positionPlayerY <= myPositionY)
                    {
                        if (-aTan < angle)
                        {
                            left = true;
                            up = false;
                            diagonal = false;
                            //Mira solamente a la derecha
                            //Debug.Log("Derecha");
                        }
                        else if (-aTan < angle * 3)
                        {
                            left = true;
                            diagonal = true;
                            up = false;
                            //Debug.Log("Diagonal: Abajo y derecha");
                        }
                        else
                        {
                            left = false;
                            up = false;
                            diagonal = false;
                            //Debug.Log("Abajo");
                        }
                    }
                    //Si el Jugador está arriba (PRIMER CUADRANTE)
                    else
                    {
                        if (aTan < angle)
                        {
                            left = true;
                            up = false;
                            diagonal = false;
                            //Mira solamente a la derecha
                            up = false;
                            //Debug.Log("Derecha");
                        }
                        else if (aTan < angle * 3)
                        {
                            //Mira Derecha y Arriba (diagonal)
                            up = true;
                            left = true;
                            diagonal = true;
                            //Debug.Log("Diagonal: Arriba y derecha");
                        }
                        else
                        {
                            up = true;
                            left = false;
                            diagonal = false;
                            //Mira solo arriba
                            //Debug.Log("Arriba");
                        }
                    }
                }
            }
        }
        anim.SetBool("Up", up);
        anim.SetBool("Left", left);
        anim.SetBool("Diagonal", diagonal);
        anim.SetBool("Die", die);
        transform.localScale = new Vector3(direction, 1f, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Grabbable"))
        {
            die = true;
        }
    }
}
