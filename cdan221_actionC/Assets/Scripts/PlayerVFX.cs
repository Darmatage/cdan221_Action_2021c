using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{

    public GameObject powerUp1;
    //public GameObject powerUp2;

    void Start()
    {
        powerUp1.SetActive(false);
        //powerUp2.SetActive(false);
    }
    public void powerup()
    {
        //Debug.Log("I am trying to show the health powerup VFX!");
        StartCoroutine(playVFX1());
    }

    IEnumerator playVFX1()
    {
        powerUp1.SetActive(true);
        //powerUp2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        powerUp1.SetActive(false);
        //powerUp2.SetActive(false);
    }

}