using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	
	Animator animator;
	Rigidbody2D playerRgb;
	float speed=2;
	public static bool grounded = true;
	public static bool dead = false;
	float jumpForce=100;
	RaycastHit2D rcast;
	GameObject floor, particle, spawn, door; 
	public static int score = 0;
	float rcastDist;
	// Use this for initialization
	bool tut;
	void Start()
	{
		animator = GetComponent<Animator>();
		tut = true;
		playerRgb = GetComponent<Rigidbody2D>();
		animator.SetBool("grounded",false);
		floor = GameObject.FindGameObjectWithTag("Floor");
		door = GameObject.FindGameObjectWithTag("Door");
		particle = GameObject.FindGameObjectWithTag("Particle");
		spawn = GameObject.FindGameObjectWithTag("Spawn");
		animator.SetTrigger("Lock");
		rcastDist = rcast.distance;
		if(Application.loadedLevelName == "Quantum1a")
			animator.SetTrigger("Unlock");

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(Application.loadedLevelName == "classical")
		{
			if(tutorialManager.i<7)
			{
				playerRgb.simulated = false;
			}
			else if(tut)
			{
				playerRgb.simulated = true;
				animator.SetTrigger("Unlock");
				tut = false;
			}
				
		}

			
//		if(Application.loadedLevelName == "Quantum1")
//		{
//			if(tutorialManagerQ.i<=12 || (tutorialManagerQ.i>=14 && tutorialManagerQ.i<17))
//			{
//				//Debug.Log ("hey");
//
//				if(grounded && Time.fixedTime>1)
//				{
//					playerRgb.simulated = false;
//				}
//			}
//			else
//			{
//				playerRgb.simulated = true;
//				animator.SetTrigger("Unlock");
//
//			}
//				
//		}
			
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		if(tutorialManager.i<9 && Application.loadedLevelName == "classical")
			if(transform.position.x>-5.2f)
				transform.position = new Vector2(-5.2f,transform.position.y);

		//if(Application.loadedLevelName == "end"))


		animator.SetBool("grounded",grounded);

//		//Landing Script (not in use currently)-------------------------------------------------------------------------
//		rcast = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.27f),new Vector2(0,-1));
//		if(rcast.distance<=0.6f && playerRgb.velocity.y<0)
//		{
//			animator.SetTrigger("Landing");
//		}
//		else
//		{
//			animator.ResetTrigger("Landing");
//		}


		//Horizontal Motion script-------------------------------------------------------------------------
        if (horizontal > 0)
		{
			animator.SetInteger("Horizontal", 1);
		}
		else if (horizontal == 0)
		{
			animator.SetInteger("Horizontal", 0);
		}
		else if (horizontal <0)
		{
			animator.SetInteger("Horizontal",-1);
		}

		if(Input.GetKey(KeyCode.Space) && Application.loadedLevelName == "classical" && grounded)
		{
//			playerRgb.velocity = new Vector2(playerRgb.velocity.x,playerRgb.);
			playerRgb.velocity = new Vector2(playerRgb.velocity.x,3f);
			grounded = false;
		}

//
//		grounded = false;//gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers();
		playerRgb.velocity = new Vector2(horizontal*speed,playerRgb.velocity.y);
//		rcast = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.4f),new Vector2(0,-1));
//		if(rcast.collider.tag=="Floor")
//		{
//			if(rcast.distance>rcastDist)
//				grounded = false;
//			else
//				grounded = true;
//		}
		Debug.Log(grounded);


	}
	void OnCollisionStay2D(Collision2D other2) 
	{

		Collider2D other = other2.collider;
		Collider2D pColl = GetComponent<CircleCollider2D>();
//		if (Input.GetKey(KeyCode.Space) && pColl.IsTouching(other) && playerRgb.velocity.y<2.5f && (Application.loadedLevelName == "classical" || Application.loadedLevelName == "end")) 
//		{
//
//			//playerRgb.AddForce(transform.up*jumpForce);
//			playerRgb.velocity = new Vector2(playerRgb.velocity.x,playerRgb.velocity.y + 2.8f);
//		}
		if((other.tag == "Floor" || other.name == "sliding_door (2)") && other2.contacts[0].point.y<transform.position.y)
		{
			grounded = true;
		}
		if(other.tag == "Particle")
		{

			StartCoroutine(Death());
		}
	}
	IEnumerator Death()
	{
		animator.SetBool("Dead",true);
		playerRgb.simulated = false;
		dead = true;
		score = score - 100;
		yield return new WaitForSeconds(0.6f);
		animator.SetBool("Dead",false);
		dead = false;

		if(Application.loadedLevelName == "classical")
		{
			if(tutorialManager.i<9)
				playerRgb.transform.position = new Vector2(-13,-0.7f);
			else
				playerRgb.transform.position = new Vector2(-4,-0.7f);
		}
		else
			playerRgb.transform.position = new Vector2(-4.71f,-1.342f);

		yield return new WaitForSeconds(0.1f);

		playerRgb.simulated = true;
		//Debug.Log(score);
	}





}
