using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxControlle : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.name.Equals("Canyon"))
        {
            Destroy(gameObject);
        }
    }

}
