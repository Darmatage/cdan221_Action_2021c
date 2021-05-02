using System.Collections;
using UnityEngine;

public class BG_Scroll : MonoBehaviour
{

	public float BGspeed = 0.5f;
	public Renderer BGrend;

	public bool isSprite = false;

	void Start()
	{
		BGrend = GetComponent<Renderer>();
		//Change the GameObject's Material Color to red
		//BGrend.material.color = Color.red;
	}

	void Update()
	{
		Vector2 hOffset = new Vector2(Time.time * BGspeed, 0);
		if (isSprite == false){
			BGrend.material.mainTextureOffset = hOffset;
		} else {
			//gameObject.GetComponent<SpriteRenderer>().material.MainTextureOffset = hOffset;; 
		}
	}
}
