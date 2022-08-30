using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool die;
    Split split_script;
    Game_Manager game_manger_script;
    // Start is called before the first frame update
    void Start()
    {
        split_script = gameObject.GetComponent<Split>();
        game_manger_script = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die == true)
        {
            Destroy(gameObject);
            Destroy(split_script.splited_player);
            game_manger_script.gameover();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            die = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            die = true;
        }
    }
}
