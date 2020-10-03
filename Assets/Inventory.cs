using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int orderInventory;

    private static int contInventory = 0;
    private static int limitInventory = 2;
    private static GameObject item;

    public static GameObject getItem()
    {
        return item;
    }

    public static void setItem(GameObject objectItem)
    {
        item = new GameObject ();
        item = objectItem;
    }

    public static int getContInventory()
    {
        return contInventory;
    }

    public static void incrementInventory()
    {
        if (contInventory < limitInventory) contInventory++;
    }

    public static void decreaseInventory()
    {
        if (contInventory > 0) contInventory--;
    }

    public static bool fullInventory()
    {
        return contInventory == limitInventory;
    }

    public static bool emptyInventory()
    {
        return contInventory == 0;
    }

    private void Update()
    {
        if (!emptyInventory())
        {
            //Mostrar sprite de la casilla
            if (orderInventory == contInventory)
            {
                //
                GetComponent<SpriteRenderer>().enabled = true;
                item.transform.position = new Vector2(transform.position.x, transform.position.y);
                item.transform.localScale = new Vector2(1, 1);
                item.GetComponent<BoxCollider2D>().enabled = false;
                item.GetComponent<OrderLayer>().enabled = false;
                item.GetComponent<Renderer>().sortingOrder = 32767;
            }
        }
        else
        {
            //Ocultar casilla
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
