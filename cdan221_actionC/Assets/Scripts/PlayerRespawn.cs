using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public GameHandler gameHandler;
    public Transform pSpawn;       // current player spawn point
    public Rigidbody2D rb2D;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        rb2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (pSpawn != null)
        {
            if (GameHandler.CurrentHealth <= 0)
            {
                //comment out lines from GameHandler abotu EndLose screen
                Debug.Log("I am going back to the last spawn point");
                Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, transform.position.z);
                gameObject.transform.position = pSpn2;
                GameHandler.playerHealth = 100;
                GameHandler.CurrentHealth = 100;
                //rb2D.isDynamic = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            pSpawn = other.gameObject.transform;
            GameObject thisCheckpoint = other.gameObject;
            StopCoroutine(changeColor(thisCheckpoint));
            StartCoroutine(changeColor(thisCheckpoint));
        }
    }

    IEnumerator changeColor(GameObject thisCheckpoint)
    {
        Renderer checkRend = thisCheckpoint.GetComponent<Renderer>();
        checkRend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        checkRend.material.color = Color.white;
    }
}