using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicScript : MonoBehaviour
{
    private GameObject player;
    public Player_Soulsight playerSoulSight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        player.GetComponent<Player_Soulsight>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.GetComponent<Player_Soulsight>().enabled = true;
            Destroy(gameObject);
        }
    }
}
