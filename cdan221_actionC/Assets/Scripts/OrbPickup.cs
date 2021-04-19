using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OrbPickup : MonoBehaviour
{

    public Player_Soulsight playerSoulSight;
    public PlayerVFX playerVFX;
    public bool isHealthPickUp = true;
    public bool isObjectPickUp = false;
    public bool isSpeedBoostPickUp = false;
    public int newOrbs = 1;
    public float speedBoost = 1f;
    public float speedTime = 1f;

    void Start()
    {
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((gameObject.tag == "MemoryOrb") && (other.gameObject.tag == "Player"))
        {
            playerSoulSight.playerGetOrbs(newOrbs);
            Debug.Log(newOrbs);
            playerVFX.powerup();
            Destroy(gameObject);
        }
    }
}