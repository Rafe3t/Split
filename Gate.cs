using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<CompositeCollider2D>());
        }
    }
}
