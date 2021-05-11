using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageInstant : MonoBehaviour {

       private GameHandler gameHandlerObj;
	   private GameObject player;
       public int damage = 100;
	   private Transform pSpn;
	   
       void Start(){
            if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
			
			if (GameObject.FindWithTag("Player") != null){
               player = GameObject.FindWithTag("Player");
            }
       }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {

            //instantiate a particle effect
			//Debug.Log("I am going back to the start");
			GameHandler.playerHealth = 100;
			GameHandler.CurrentHealth = 100;
			//gameHandler.TakeDamage(damage);
			//rb2D.isKinematic = false;
			
			pSpn = player.GetComponent<PlayerRespawn>().pSpawn;
			Vector3 pSpn2 = new Vector3(pSpn.position.x, pSpn.position.y, player.transform.position.z);
			player.transform.position = pSpn2;
		}
    }

}
