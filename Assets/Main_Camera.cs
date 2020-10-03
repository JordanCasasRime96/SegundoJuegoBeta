using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    Transform target;
    float tLX, tLY, bRX, bRY; //Valores de los límites

    void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform; //Ser hijo de Player
    }

    //Actualizarse constantemente
    void Update() {
        transform.position = new Vector3( //Que se traslade junto con su hijo (Player)
            target.position.x, //Seguir en la posicion X
            target.position.y, //Seguir en la posicion Y
            -10 //Mantenerse en Z=-10, debido a que se genera un bug si ambos estan en el mismo Z
        );
    }

    public void SetBound (GameObject map) {
        float cameraSize = Camera.main.orthographicSize;

    }
}
