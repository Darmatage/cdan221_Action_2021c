using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    public Player_Soulsight playerSoulSight;
    public float soulEnergyMax;
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;


    void Start()
    {
        playerSoulSight = GameObject.FindWithTag("Player").GetComponent<Player_Soulsight>();
        soulEnergyMax = Player_Soulsight.soulEnergyMax;
        powerUp1.SetActive(false);
        powerUp2.SetActive(false);
        powerUp3.SetActive(false);
    }
    public void powerup()
    {
        //Debug.Log("I am trying to show the health powerup VFX!");
        StartCoroutine(playVFX1());
    }
    public void powerup2()
    {
        //Debug.Log("I am trying to show the health powerup VFX!");
        StartCoroutine(playVFX2());
    }
    public void powerup3()
    {
        //Debug.Log("I am trying to show the health powerup VFX!");
        StartCoroutine(playVFX3());
    }
    IEnumerator playVFX1()
    {
        powerUp1.SetActive(true);
        //powerUp2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        powerUp1.SetActive(false);
        //powerUp2.SetActive(false);
    }
    IEnumerator playVFX2()
    {
        powerUp2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        powerUp2.SetActive(false);
    }
    IEnumerator playVFX3()
    {
        powerUp3.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        //powerUp3.SetActive(false);
    }
    IEnumerator stopVFX3()
    {
        //powerUp3.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        powerUp3.SetActive(false);
    }

    public void Update()
    {
        if (playerSoulSight.SoulsightActive == true)
        {
            StartCoroutine("playVFX3");
        }
        else if (playerSoulSight.SoulsightActive == false)
        {
            StartCoroutine("stopVFX3");
        }

    }

}