using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splited_Player : MonoBehaviour
{
    Death deathscript;
    // Start is called before the first frame update
    void Start()
    {
        deathscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            deathscript.die = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            deathscript.die = true;
        }
    }
}
