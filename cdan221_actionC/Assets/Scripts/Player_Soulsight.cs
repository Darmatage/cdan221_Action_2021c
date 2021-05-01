using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Soulsight : MonoBehaviour{
	public AudioSource SoulsightOn;
	public AudioSource SoulsightOff;
	//NOTE: Soulsight platforms need to be active in scene before hitting play
	//NOTE #2: orbCurrentPower is a static variable in the GameHandler
	public PlayerVFX playerVFX;
	public GameObject soulSetting;
	//private float soulTimer = 0f;
	public bool SoulsightActive = false;
	
	public GameHandler gameHandler;
	private float powerPerOrb = 0.1f;
	public static float soulEnergy = 0;
	public static float soulEnergyMax = 3f;
	
	public Image SoulsightCircle;
	
    // Start is called before the first frame update
    void Start()
    {
		playerVFX = GameObject.FindWithTag("Player").GetComponent<PlayerVFX>();
		
		if (GameObject.FindWithTag("Soulsight") != null){
			soulSetting = GameObject.FindWithTag("Soulsight");
			soulSetting.SetActive(false);
		}
		
		if (GameObject.FindWithTag("GameHandler") != null){
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
			soulSetting.SetActive(false);
		}
		
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SoulSight") && (soulSetting != null)){
			if ((soulEnergy > 0) && (SoulsightActive == false)){
				playerVFX.powerup();
				SoulsightOn.Play();
				soulSetting.SetActive(true);
				SoulsightActive = true;
				//Debug.Log("I hit e - on");
				//soulTimer = 0f;
				//StartCoroutine(SoulRemove(soulEnergy));
			}
			else if (SoulsightActive == true){
				//playerVFX.powerup();
				soulSetting.SetActive(false);
				SoulsightActive = false;
				SoulsightOff.Play();
				//soulTimer = 0f;
				//StopCoroutine(SoulRemove(soulEnergy));
				//Debug.Log("I hit e - off");
			}
		}
		if (soulEnergy <= 0){
			soulEnergy = 0;
		}
	}
	
	
	void FixedUpdate(){

		if (SoulsightActive == true){
			//soulTimer += 0.01f;
			soulEnergy -= 0.01f;
			Debug.Log("" + soulEnergy);
			gameHandler.playerUpdateSoulEnergy(-0.01f);
			if (soulEnergy <= 0){
				SoulsightActive = false;
				soulEnergy = 0;
				if (soulSetting != null){
					soulSetting.SetActive(false);
				}
			}
		}
		
		if ((SoulsightActive == false)&&(soulEnergy < soulEnergyMax)){ 
			if (gameObject.GetComponent<PlayerJump>().IsGrounded()){
				soulEnergy += 0.01f;
				Debug.Log("" + soulEnergy);
				gameHandler.playerUpdateSoulEnergy(+0.01f);
			}
			
		}
		
		
		//soulsight meter fill:
		SoulsightCircle.fillAmount = soulEnergy / soulEnergyMax; 
		
				
	}
	
	
	public void playerGetOrbs(int newOrbs)
    {
		soulEnergyMax += powerPerOrb;
		gameHandler.playerUpdateSoulEnergy(powerPerOrb);
        //gotOrbs += newOrbs;
        //updateStatsDisplay();
    }
	
	
	// IEnumerator SoulRemove(float soulEnergy){
		// yield return new WaitForSeconds(soulEnergy);  
		// SoulsightActive = false;
		// if (soulSetting != null){
			// soulSetting.SetActive(false);
		// }
		// gameHandler.orbCurrentPower = soulEnergy;
	// }
	
	
}
