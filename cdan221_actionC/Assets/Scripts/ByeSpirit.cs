using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ByeSpirit : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject spirit;
    //private bool fadeOut, fadeIn;
    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        spirit = GameObject.FindWithTag("SpiritNPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {

            //Here it would use the "level" variable to load the next scene
            StartCoroutine(PlayText1());
            StartCoroutine(PlayText2());
            //StartCoroutine(Fade());
            //Debug.Log("I hit the collider");
        }
    }
    IEnumerator PlayText1()
    {
        text1.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        text1.SetActive(false);


    }
    IEnumerator PlayText2()
    {
        yield return new WaitForSeconds(2.0f);
        text2.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        text2.SetActive(false);
        StartCoroutine(PlayText2());
        Destroy(spirit);
        Destroy(gameObject);

    }
    //IEnumerator Fade()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    Color spiritColor = spirit.GetComponent<Renderer>().material.color;
    //    float fadeAmount = spiritColor.a - (fadeSpeed * Time.deltaTime);

    //    spiritColor = new Color(spiritColor.r, spiritColor.g, spiritColor.b, fadeAmount);
    //    spirit.GetComponent<Renderer>().material.color = spiritColor;

    //}
}
