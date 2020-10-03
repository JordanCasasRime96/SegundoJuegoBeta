using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject puente;
    private bool grabbed;
    RaycastHit2D hit;
    private float distance = 0.5f;
    public Transform holdPoint;
    private float distanceHoldPoint = 0.1f;
    public float throwforce = 50f;
    public LayerMask notgrabbed;

    private float ejeX;
    private float ejeY;

    private int cont = 0;

    void Update()
    {
        ejeX = PlayerController.ejeX;
        ejeY = PlayerController.ejeY;

        if (cont > 1)
        {
            Inventory.decreaseInventory();
            Inventory.getItem().transform.localScale = new Vector2(0,0);
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            //Si no estás agarrando nada, vas a crear el evento para agarrarlo
            if (!grabbed)
            {
                if (hit.collider != null && hit.collider.tag.Equals("Player"))
                {
                    Debug.Log("Hablar");
                    MyMessage.viewText();
                }
                //Si agarra un item
                if (hit.collider != null && hit.collider.tag.Equals("Item"))
                {
                    if (!Inventory.fullInventory())
                    {
                        Inventory.setItem(hit.collider.gameObject);
                        Inventory.incrementInventory();
                    }
                }
                else
                {
                    Physics2D.queriesStartInColliders = false;
                    hit = Physics2D.Raycast(transform.position, new Vector2(ejeX, ejeY) * transform.localScale.x, distance);
                    if (hit.collider != null && hit.collider.tag.Equals("Grabbable"))
                    {
                        grabbed = true;

                    }
                }
            }
            //Tirar el objeto
            else if (Physics2D.OverlapPoint(holdPoint.position, notgrabbed))
            {
                grabbed = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(ejeX, ejeY) * throwforce;
                    hit.collider.isTrigger = false;
                }
            }
        }
        //Cuando agarras un objeto
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdPoint.transform.position;
            hit.collider.isTrigger = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (ejeY != 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y - 0.4f), new Vector2(transform.position.x, transform.position.y + distance * ejeY * 2f - 0.2f));
            holdPoint.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + (distanceHoldPoint + 0.5f) * ejeY);
        }
        else
        {
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y - 0.4f), new Vector2(transform.position.x + distance * ejeX, transform.position.y - 0.4f));
            holdPoint.gameObject.transform.position = new Vector2(transform.position.x + distanceHoldPoint * ejeX * 8f, transform.position.y);
        }
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("BridgeActivate"))
        {
            cont++;
        }
    }
}
