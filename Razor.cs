using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razor : MonoBehaviour
{
    Rigidbody2D rb;
    public float rotspeed;
    public float movspeed;
    public Vector2 point1;
    public Vector2 point2;
    float dist;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dist = Mathf.Sqrt(Mathf.Pow(point1.x - point2.x, 2f) + Mathf.Pow(point1.y - point2.y, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = rotspeed;


        if(Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - point2.x, 2f) + Mathf.Pow(gameObject.transform.position.y - point2.y, 2f)) >= dist)
        {
            rb.velocity = new Vector2(point2.x - point1.x, point2.y - point1.y).normalized * movspeed ;
            
        }

        if(Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x-point1.x,2f)+Mathf.Pow(gameObject.transform.position.y-point1.y,2f)) >= dist)
        {
            rb.velocity = new Vector2(point1.x - point2.x, point1.y - point2.y).normalized * movspeed ;
            
        }
        
    }
}
