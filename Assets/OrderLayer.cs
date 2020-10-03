using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLayer : MonoBehaviour
{
    public int regulador = 0;

    void LateUpdate()
    {
        foreach (var rend in GetComponentsInChildren<Renderer>())
        {
            rend.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.max.y * 1000 + regulador);
        }
    }
}
