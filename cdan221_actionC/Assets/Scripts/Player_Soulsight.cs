using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Soulsight : MonoBehaviour{
	//NOTE: Soulsight platforms need to be active in scene before hitting play

	public PlayerVFX playerVFX;
	public GameObject soulSetting;
	public static float soulCoolDown = 3f;
	private float soulTimer = 0f;
	public bool SoulsightActive = false;
	
    // Start is called before the first frame update
    void Start()
    {
		playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
		if (GameObject.FindWithTag("Soulsight") != null){
			soulSetting = GameObject.FindWithTag("Soulsight");
			
			soulSetting.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
		if (Input.GetButtonDown("SoulSight") && (soulSetting != null)){
			playerVFX.powerup();
			soulSetting.SetActive(true);
			SoulsightActive = true;
			soulTimer = 0f;
			StartCoroutine(SoulRemove(soulCoolDown));
		}
    }
	
	
	void FixedUpdate(){
		soulTimer += 0.01f;
		
		//Debug.Log("" + soulTimer);
		
		
	}
	
	
	IEnumerator SoulRemove(float soulCoolDown){
		yield return new WaitForSeconds(soulCoolDown);  
		SoulsightActive = false;
		if (soulSetting != null){
			soulSetting.SetActive(false);
		}
	}
	
	
}
