using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    public GameObject splited_player;
    public GameObject sframe;
    public GameObject cframe;
    public GameObject portal1;
    public Portal1 portal1_script;
    bool passed = false;
    bool portpassed = false;
    bool portportpassed = false;
    // Start is called before the first frame update
    void Start()
    {
        sframe.SetActive(false);
        cframe.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        portal1 = GameObject.FindGameObjectWithTag("Portal1");
        portal1_script = portal1.GetComponent<Portal1>();
    }

    void Update()
    {
        if(player != null)
        {
            if (player.transform.position.x >= 66f && passed == false)
            {
                sframe.SetActive(true);
                cframe.SetActive(true);
                passed = true;
            }
            if (player.transform.position.x >= 28f && portpassed == false)
            {
                cframe.SetActive(true);
                portpassed = true;
            }
            splited_player = GameObject.FindGameObjectWithTag("Splited_Player");

            if (portal1_script.lockedin1 == true && portportpassed == false)
            {
                cframe.SetActive(false);
                portportpassed = true;
            }
            if (splited_player != null)
            {
                sframe.SetActive(false);
                cframe.SetActive(false);
            }
        }
        
    }

}
