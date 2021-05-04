using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOrb : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        text3.SetActive(false);

        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((gameObject.tag == "MemoryOrb") && (other.gameObject.tag == "Player"))
        {

            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(PlayText3());

            gameObject.GetComponent<Collider2D>().enabled = false;

            orbpickupSFX.Play();

            playerSoulSight.playerGetOrbs(newOrbs);
            Debug.Log(newOrbs);
            playerVFX.powerup2();

            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(destroyOrb());

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
