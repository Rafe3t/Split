using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    public GameObject player;
    public Split split_script;
    public float dist;
    Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        split_script = player.GetComponent<Split>();
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (split_script.splited_player == null)
            {
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
            }

            else
            {
                dist = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - split_script.splited_player.transform.position.x, 2f) + Mathf.Pow(player.transform.position.y - split_script.splited_player.transform.position.y, 2f));

                gameObject.transform.position = new Vector3((split_script.splited_player.transform.position.x + player.transform.position.x) / 2f, (split_script.splited_player.transform.position.y + player.transform.position.y) / 2f, -10f);
                if (dist > 8f)
                {
                    cam.orthographicSize = (dist + 2f) / 2f;
                }
                else
                {
                    cam.orthographicSize = 5f;
                }
            }
        }
        
    }
}
