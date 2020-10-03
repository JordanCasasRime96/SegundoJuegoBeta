using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4f;    //El valor de la velocidad, tener en cuenta que el IDE tiene más prioridad su valor que el script

    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    public static float ejeX = 0f;
    public static float ejeY = -1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Detectar movimiento 2D
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        /*
        //Detectar movimiento 3D
        Vector3 mov = new Vector3(  //Instanciar valores en 3D
            Input.GetAxisRaw("Horizontal"), //Valor cuando presionas izquierda(1) o derecha(-1)
            Input.GetAxisRaw("Vertical"), //Valor cuando presionas arriba(1) o abajo (-1)
            0   //Valor en el eje Z, como no puedes desplazarte en ese eje se mantendrá en cero.
        );
        
        transform.position = Vector3.MoveTowards(   //Genera la traslacion del personaje
            transform.position, //Posicion actual
            transform.position + mov,   //Posicion cuando presionas la tecla de movimiento
            speed * Time.deltaTime  //La velocidad y aceleracion que va trasladandose el personaje
        );
        */

        //Momentos del EJE X, Y detectado, cambia su animación
        if (mov != Vector2.zero)
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        capturePosition();
    }

    private void FixedUpdate()
    {
        //Movimiento en el fixed por físicas
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

    private void capturePosition()
    {
        if (mov.x != 0 || mov.y !=0)
        {
            ejeX = mov.x;
            ejeY = mov.y;
        }
    }
}