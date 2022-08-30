using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = gameObject.transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"  || collision.gameObject.tag == "Splited_Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Death>().die = true;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
