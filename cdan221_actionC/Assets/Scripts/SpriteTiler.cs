using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpriteTiler : MonoBehaviour {

	public Transform BG1;
	public Transform BG2;
	public Transform BG3;

	private Vector2 BG1Start;
	private Vector2 BG2Start;
	private Vector2 BG3Start;

	public float BGspeed = 8f; 
	public float BGdistance = 40f; 		//30-60 
	public Transform playerTarget; 

	public bool moveLeft = true;

	void Start(){ 
		playerTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
		BG1Start = new Vector2 (BG1.position.x, BG1.position.y);
		BG2Start = new Vector2 (BG2.position.x, BG2.position.y);
		BG3Start = new Vector2 (BG3.position.x, BG3.position.y);
	}

	void FixedUpdate(){ 
		//transform.position.x = playerTarget.position.x; //set parent object to player x-position 
		
		transform.position = new Vector2(playerTarget.position.x, transform.position.y);
		
		int moveDir = 1;
		if (moveLeft == false){moveDir = 1;}
		else {moveDir = -1;}
		
		float BG1rand = Random.Range(0.5f, 2f);
		float BG2rand = Random.Range(0.5f, 2f);		
		float BG3rand = Random.Range(0.5f, 2f);		
		
		float bg1Pos = moveDir * BG1rand * BGspeed * Time.deltaTime;
		float bg2Pos = moveDir * BG2rand * BGspeed * Time.deltaTime;
		float bg3Pos = moveDir * BG3rand * BGspeed * Time.deltaTime;
		
		BG1.localPosition = new Vector2(BG1.localPosition.x + bg1Pos, BG1.localPosition.y + (BG1rand/20));
		BG2.localPosition = new Vector2(BG2.localPosition.x + bg2Pos, BG2.localPosition.y + (BG2rand/20));
		BG3.localPosition = new Vector2(BG3.localPosition.x + bg3Pos, BG3.localPosition.y + (BG3rand/20));

		Debug.Log("BG1 position = " + BG1.localPosition.x + "\n : BG1.position.x" + (BG1Start.x + BGdistance));

		if (Mathf.Abs(BG1.position.x - BG1Start.x) >= (Mathf.Abs(BG1Start.x) + BGdistance)){
			BG1.localPosition = BG1Start;
			BG2.localPosition = BG2Start;
			BG3.localPosition = BG3Start;
		}
	}
}
