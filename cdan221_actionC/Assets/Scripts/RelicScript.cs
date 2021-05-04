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
    private Rigidbody2D rb;
    private BoxCollider2D boxcollider;

    public GameObject orbs;
    public GameObject soulSetting;
    //public GameObject arrows;
    public GameObject arrow1;
    public GameObject arrow2;
    //public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        arrow1.SetActive(false);
        arrow2.SetActive(false);

        player = GameObject.FindWithTag("Player");
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        player.GetComponent<Player_Soulsight>().enabled = false;
        canvas = GameObject.FindWithTag("Canvas");
        canvas.SetActive(false);
        playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
        boxcollider = GetComponent<BoxCollider2D>();

        orbs = GameObject.FindWithTag("MemoryOrb");
        soulSetting = GameObject.FindWithTag("Soulsight");
        soulSetting.SetActive(false);
        orbs.active = false;
        //sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        //arrows = GameObject.FindWithTag("Arrow");
        //arrows.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            arrow1.SetActive(true);
            arrow2.SetActive(true);

            //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            player.GetComponent<Player_Soulsight>().enabled = true;
            playerVFX.powerup2();
            canvas.SetActive(true);
            StartCoroutine(DeleteText1());
            text2.SetActive(false);
            orbs.active = true;
            soulSetting.SetActive(true);
            //arrows.SetActive(true);
            
        }
        IEnumerator DeleteText1()
        {
            yield return new WaitForSeconds(2.0f);
            text2.SetActive(true);
            StartCoroutine(DeleteText2());

        }
        IEnumerator DeleteText2()
        {
            yield return new WaitForSeconds(5.0f);
            text1.SetActive(false);
            text2.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(boxcollider);
            //Debug.Log("Destroy rb");
        }
    }
}
