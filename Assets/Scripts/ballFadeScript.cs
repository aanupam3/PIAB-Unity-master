using UnityEngine;
using System.Collections;

public class ballFadeScript : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	SpriteRenderer spr;
	public static bool ball = false;
	//public static bool fade = false;
	void Start () {

		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
//		spr.color = Color.red;
//		Debug.Log(spr.color);
		anim.SetTrigger("ballFade");
		ball = false;
		gameObject.GetComponent<Rigidbody2D>().simulated = false;

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(ball)
		{

			Rigidbody2D ballRB = GetComponent<Rigidbody2D>();
			float initV = 2f;
			ballRB.velocity = new Vector2(initV,0);
			
			GetComponent<BallMotion>().initV = initV;
			float KE = 0.5f*initV*initV;
			GetComponent<BallMotion>().TE = GetComponent<BallMotion>().PE + KE;
			gameObject.GetComponent<Rigidbody2D>().simulated = true;
			ball = false;
		}
		if(slidingDoorScript2.doorOpen2==true)
			gameObject.GetComponent<Rigidbody2D>().simulated = false;
		
		
	}
}
