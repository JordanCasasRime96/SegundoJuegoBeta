using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpZone : MonoBehaviour
{
    //Seleccionas a que dirección te quiere teletransportar el warpZone
    public bool up;
    public bool down;
    public bool left;
    public bool rigth;

    //La cantidad de pixeles que te desplazará al jugador
    private float ejeXPlayer = 1.9f;
    private float ejeYPlayer = 2f;

    //La cantidad de pixeles que se desplazará la cámara
    private float ejeXCamera = 19f;
    private float ejeYCamera = 12f;

    //Captura el objeto CAMARA "MainCamera" el cual se utilizará para su traslación
    private new GameObject camera;
    private const string Tag = "MainCamera";

    // Start is called before the first frame update
    private void Awake()
    {
        //Oculta el sprite
        GetComponent<SpriteRenderer>().enabled = false;
        //Captura el objeto Cámara
        camera = GameObject.FindGameObjectWithTag(Tag);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Si colisionas, busca el jugador "Player"
        if (collision.CompareTag("Player"))
        {
            if (up) //Si vas arriba
            {
                collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + ejeYPlayer, collision.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + ejeYCamera, camera.transform.position.z);
            }
            if (down) //Si estas bajando
            {
                collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - ejeYPlayer, collision.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - ejeYCamera, camera.transform.position.z);
            }
            if (left) //Si vas a la izquierda
            {
                collision.transform.position = new Vector3(collision.transform.position.x - ejeXPlayer, collision.transform.position.y, collision.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x - ejeXCamera, camera.transform.position.y, camera.transform.position.z);
            }
            if (rigth) //Si vas a la derecha
            {
                collision.transform.position = new Vector3(collision.transform.position.x + ejeXPlayer, collision.transform.position.y, collision.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x + ejeXCamera, camera.transform.position.y, camera.transform.position.z);
            }
        }

    }
}
