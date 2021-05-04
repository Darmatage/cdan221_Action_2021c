using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutFirstOrb : MonoBehaviour
{
    public GameObject text3;

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
    public GameObject orb1UI;

    public GameObject arrow1;
    public GameObject arrow2;

    // Start is called before the first frame update
    void Start()
    {
        text3.SetActive(false);

        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
        orb1UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((gameObject.tag == "MemoryOrb") && (other.gameObject.tag == "Player"))
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);

            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(PlayText3());

            orbpickupSFX.Play();

            playerSoulSight.playerGetOrbs(newOrbs);
            //Debug.Log(newOrbs);
            playerVFX.powerup2();

            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(destroyOrb());

            orb1UI.SetActive(true);

        }
    }
    IEnumerator PlayText3()
    {
        text3.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        text3.SetActive(false);

    }
    IEnumerator destroyOrb()
    {
        
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
