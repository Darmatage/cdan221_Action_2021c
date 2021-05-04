using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicScript : MonoBehaviour
{
    private GameObject player;
    public Player_Soulsight playerSoulSight;
    public PlayerVFX playerVFX;
    public GameObject canvas;
    public GameObject text1;
    public GameObject text2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        player.GetComponent<Player_Soulsight>().enabled = false;
        canvas = GameObject.FindWithTag("Canvas");
        canvas.SetActive(false);
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();

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
            playerVFX.powerup();
            canvas.SetActive(true);
            StartCoroutine(DeleteText1());
            text2.SetActive(false);
        }

        IEnumerator DeleteText1()
        {
            yield return new WaitForSeconds(3.0f);
            text1.SetActive(false);
            text2.SetActive(true);
            StartCoroutine(DeleteText2());
            
        }
        IEnumerator DeleteText2()
        {
            yield return new WaitForSeconds(5.0f);
            text2.SetActive(false);
            Destroy(gameObject);
        }
    }
}
