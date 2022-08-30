using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    Animator anim;
    GameObject player;
    GameObject splited_player;
    GameObject Portal1;
    public Portal1 portal1_script;
    public GameObject teleportobj;
    public bool teleport2;
    public bool lockedin2 = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Portal1 = GameObject.FindGameObjectWithTag("Portal1");
        portal1_script = Portal1.GetComponent<Portal1>();
    }
    // Update is called once per frame
    void Update()
    {
        if (splited_player == null)
        {
            splited_player = GameObject.FindGameObjectWithTag("Splited_Player");
        }
        if (lockedin2 == false)
        {
            anim.SetBool("Teleport", false);
        }

    }
    public void portal2fun()
    {
        if (teleport2 == true && lockedin2 == false)
        {
            teleportobj.transform.position = Portal1.transform.position;
            lockedin2 = true;
            portal1_script.lockedin1 = false;
            anim.SetBool("Teleport", true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Splited_Player")
        {
            teleportobj = collision.gameObject;
            teleport2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Splited_Player")
        {
            if (Physics2D.IsTouching(gameObject.GetComponent<CircleCollider2D>(), player.GetComponent<CircleCollider2D>()) == true)
            {
                teleportobj = player;
            }
            else if (splited_player != null && Physics2D.IsTouching(gameObject.GetComponent<CircleCollider2D>(), splited_player.GetComponent<CircleCollider2D>()) == true)
            {
                teleportobj = splited_player;
            }
            else
            {
                teleportobj = null;
                teleport2 = false;
            }

        }
    }
}
