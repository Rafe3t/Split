using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shoot;
    public GameObject bullet;
    float time;
    public float time_wait;
    bool touched;
    float angle_speed = -20f;
    float angle;
    float new_angle;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("bullet");
        angle = gameObject.transform.eulerAngles.z;
        new_angle = gameObject.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(touched == true)
        {
            if(angle == 180f)
            {
                new_angle = 240f;
            }
            if(angle == 0 || angle == 90)
            {
                new_angle = -60f;
            }
        }
        else
        {
            if (Time.time >= time + time_wait)
            {
                Instantiate(bullet, shoot.position, shoot.rotation);
                time = Time.time;
            }
        }
        angle = Mathf.SmoothDamp(angle, new_angle,ref angle_speed,1f);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        touched = true;
    }
}
