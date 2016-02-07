using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	SpriteRenderer spr;
	public bool fade = false;
	//public static bool fade = false;
	void Start () {

		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
//		spr.color = Color.red;
//		Debug.Log(spr.color);
		//gameObject.GetComponent<Rigidbody2D>().simulated = false;
		if(gameObject.name == "Button")
			anim.SetTrigger("buttonFade");



	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fade)
		{
			if(gameObject.tag != "Button")
				anim.SetTrigger("fade");

			//gameObject.GetComponent<Rigidbody2D>().simulated = true;
			//gameObject.GetComponent<Rigidbody2D>().simulated = true;
		}
		
		
		
	}
}
