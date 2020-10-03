using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    //Para almacenar el punto del destino
    public GameObject target;

    //Para almacenar el mapa del destino
    //private GameObject targetMap;

    private void Awake()
    {
        //Nos aseguramos de que target se ha establecido o lanzaremos except
        Assert.IsNotNull(target);

        //Si queremos podemos esconder el debug(sprite) de los warps
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        //Mandará un mensaje que falta llenar ese valor
        //Assert.IsNotNull(targetMap);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //Actualizamos la posicion
            collision.transform.position = target.transform.GetChild(0).transform.position;
    }
}
