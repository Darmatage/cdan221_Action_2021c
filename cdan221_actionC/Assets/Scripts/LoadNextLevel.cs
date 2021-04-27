using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour

{
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene(NextScene);
            //Debug.Log("I hit the collider");
        }
    }
}

