using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public GameObject splited_player;
    public GameObject splited_player_prefab;
    public float split_dist;
    public bool splited = false;
    bool ready_split;
    bool ready_unite;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        splited_player_prefab = Resources.Load<GameObject>("Players/Splited_Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (splited_player != null)
        {
            splited_player.transform.localScale = gameObject.transform.localScale;
            dist = Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - splited_player.transform.position.x, 2f) + Mathf.Pow(gameObject.transform.position.y - splited_player.transform.position.y, 2f));
        }
        
    }
    public void splitfun()
    {
        if ( splited == false && ready_split == true)
        {
            split();

        }

        if ( splited == true && ready_unite == true && dist < 0.5f)
        {
            unite();
        }
    }

    void split()
    {
        splited_player = Instantiate(splited_player_prefab, new Vector2(gameObject.transform.position.x - split_dist, gameObject.transform.position.y), gameObject.transform.rotation);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + split_dist, gameObject.transform.position.y);
        splited = true;
        gameObject.transform.localScale = gameObject.transform.localScale - new Vector3(0.02f, 0.02f, 0.02f);
    }
    void unite()
    {
        if (splited_player != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Splited_Player"));
        }
        splited = false;
        gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.02f, 0.02f, 0.02f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Split")
        {
            ready_split = true;
        }

        if (collision.gameObject.tag == "Unite")
        {
            ready_unite = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Split")
        {
            ready_split = false;
        }

        if (collision.gameObject.tag == "Unite")
        {
            ready_unite = false;
        }
    }
    
}
