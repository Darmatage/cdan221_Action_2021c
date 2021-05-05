﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FifthOrb : MonoBehaviour
{
    public AudioSource orbpickupSFX;
    public Player_Soulsight playerSoulSight;
    public PlayerVFX playerVFX;
    public bool isHealthPickUp = true;
    public bool isObjectPickUp = false;
    public bool isSpeedBoostPickUp = false;
    public int newOrbs = 1;
    public float speedBoost = 1f;
    public float speedTime = 1f;

    public Canvas canvas;
    public GameObject orb5UI;

    void Start()
    {
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
        orb5UI.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((gameObject.tag == "MemoryOrb") && (other.gameObject.tag == "Player"))
        {

            gameObject.GetComponent<Collider2D>().enabled = false;

            orbpickupSFX.Play();

            playerSoulSight.playerGetOrbs(newOrbs);
            Debug.Log(newOrbs);
            playerVFX.powerup2();

            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(destroyOrb());

            orb5UI.SetActive(true);
        }
    }

    IEnumerator destroyOrb()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


}