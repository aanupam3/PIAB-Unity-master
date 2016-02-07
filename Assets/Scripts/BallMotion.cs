using UnityEngine;
using System.Collections;

public class BallMotion : MonoBehaviour {

	public float KE, PE; 
	public float TE;
	public float height, initHeight, maxHeight; 
	public float initV;
	float gHeight, gWidth, g=9.8f;
	public Rigidbody2D ballRB;
	GameObject bg;
	RectTransform bgrt;
	GameObject TEPlot, PEPlot;

	// Use this for initialization
	void Start () {
		bg = GameObject.Find("BG");
		bgrt = bg.GetComponent<RectTransform>();

		ballRB = GetComponent<Rigidbody2D>();

		//initV = -0.0f;
		ballRB.velocity = new Vector2(initV,0);

		gHeight = bgrt.rect.height;
		initHeight = transform.position.y + 1.62f;

		PE = g*initHeight;
		KE = 0.5f*initV*initV;
		TE = PE + KE;
		//Debug.Log (PE);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		height = transform.position.y + 1.62f;

		PE = g*height;
		KE = TE - PE;
		float speed = Mathf.Sqrt (KE * 2);
		ballRB.velocity = ballRB.velocity.normalized * speed/1.5f;

		//if(maxHeight<height)
		maxHeight = Mathf.Lerp (maxHeight, TE/g, 0.05f);
		//Debug.Log (maxHeight);
	
	}

	public float SetTE()
	{
		return TE;
	}

}
