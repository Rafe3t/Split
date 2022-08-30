using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    Animator anim;
    GameObject player;
    GameObject splited_player;
    GameObject Portal2;
    public Portal2 portal2_script;
    public GameObject teleportobj;
    public bool teleport1;
    public bool lockedin1;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Portal2 = GameObject.FindGameObjectWithTag("Portal2");
        portal2_script = Portal2.GetComponent<Portal2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (splited_player == null)
        {
            splited_player = GameObject.FindGameObjectWithTag("Splited_Player");
        }
        if (lockedin1 == false)
        {
            anim.SetBool("Teleport", false);
        }
    }
    public void portal1fun()
    {
        if (teleport1 == true && lockedin1 == false)
        {
            teleportobj.transform.position = Portal2.transform.position;
            lockedin1 = true;
            portal2_script.lockedin2 = false;
            anim.SetBool("Teleport", true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Splited_Player")
        {
            teleportobj = collision.gameObject;
            teleport1 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Splited_Player")
        {
         if(Physics2D.IsTouching(gameObject.GetComponent<CircleCollider2D>(),player.GetComponent<CircleCollider2D>()) == true)
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
                teleport1 = false;
            }
            
        }
    }
}
