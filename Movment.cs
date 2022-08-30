using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D collid;
    public float speed;
    public Split split_script;
    public Joystick joystick;
    float joystick_horzspeed;
    float joystick_vertspeed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        collid = gameObject.GetComponent<CircleCollider2D>();
        split_script = gameObject.GetComponent<Split>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick != null)
        {
            if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
            {
                joystick_horzspeed = joystick.Horizontal;
            }
            else
            {
                joystick_horzspeed = 0f;
            }

            if (joystick.Vertical > 0.2f || joystick.Vertical < 0.2f)
            {
                joystick_vertspeed = joystick.Vertical;
            }
            else
            {
                joystick_vertspeed = 0f;
            }

            rb.velocity = new Vector2(joystick_horzspeed * speed, joystick_vertspeed * speed);
        }
       
        
        
        if(split_script.splited_player != null)
        {
            Rigidbody2D splited_player_rb = split_script.splited_player.GetComponent<Rigidbody2D>();
            splited_player_rb.velocity = new Vector2(joystick_horzspeed * -speed, joystick_vertspeed * speed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Splited_Player")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<CircleCollider2D>());
        }
    }

}
