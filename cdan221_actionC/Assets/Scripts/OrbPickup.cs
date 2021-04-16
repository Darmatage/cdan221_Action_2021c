using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OrbPickup : MonoBehaviour
{

    public GameHandler gameHandler;
    public PlayerVFX playerVFX;
    public bool isHealthPickUp = true;
    public bool isObjectPickUp = false;
    public bool isSpeedBoostPickUp = false;
    public int newOrbs = 1;
    public float speedBoost = 1f;
    public float speedTime = 1f;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((gameObject.tag == "MemoryOrb") && (other.gameObject.tag == "Player"))
        {
            gameHandler.playerGetOrbs(newOrbs);
            Debug.Log(newOrbs);
            playerVFX.powerup();
            Destroy(gameObject);
        }
    }
}