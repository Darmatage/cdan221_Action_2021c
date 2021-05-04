using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour
{

    public GameHandler gameHandler;
    public Transform playerPos;
    private Transform pSpn;
    private GameObject player;
    public Rigidbody2D rb2D;
    public int damage = 10;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        player = GameObject.FindWithTag("Player");
        rb2D = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pSpn = player.GetComponent<PlayerRespawn>().pSpawn;

        if (playerPos != null)
        {
            if (transform.position.y >= playerPos.position.y)
            {
                //instantiate a particle effect
                Debug.Log("I am going back to the start");
                GameHandler.playerHealth = 100;
                GameHandler.CurrentHealth = 100;
                //gameHandler.TakeDamage(damage);
                rb2D.isKinematic = false;
                Vector3 pSpn2 = new Vector3(pSpn.position.x, pSpn.position.y, playerPos.position.z);
                playerPos.position = pSpn2;
                
            }
        }
    }
}