using UnityEngine;
using System.Collections;

public class weightScript : MonoBehaviour {

	// Use this for initialization
	Animator animator;
	float oscillate;
	bool increase = true;
	GameObject player, spawn;
	public bool picked = false;
	int flag;
	float extent, startY;
	Vector2 initPosition;
	void Start () {
		initPosition = gameObject.transform.position;
		flag =0;
		extent = 0.05f;
		startY = transform.position.y;
		oscillate = 0.001f;
		animator = gameObject.GetComponent<Animator>();
		player =  (GameObject)GameObject.Find("PlayerQ");
		spawn=  GameObject.FindGameObjectWithTag("Spawn");
		gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+oscillate);

	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(Mathf.Abs(startY-transform.position.y)>=extent)
			oscillate = -1*oscillate;

		gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+oscillate);
		flag =1;
	}


	void OnTriggerStay2D(Collider2D other) 
	{

		
		if(Input.GetKeyUp(KeyCode.UpArrow) && other.tag == "Player" && picked == false && flag==1)
		{
			picked = true;
			flag = 0;
		}
		else if(Input.GetKeyUp(KeyCode.UpArrow) && other.tag == "Player" && picked == true && flag==1)
		{
			picked = false;
			flag = 0;
		}
		if(other.tag == "Weight")
//			Debug.Log ("WeightTouch");
		if(other.tag == "Weight" && !picked)
		{
			//Debug.Log ("WeightTouch");
//			float shifter = 0.01f;
			gameObject.transform.position = initPosition;
			                                   
		}
		if(picked)
		{
			gameObject.transform.position = player.transform.position;
			//spawn.GetComponent<Animator>().SetBool("spawnActive",true);

		}

		if(playerController.dead)
		{
			picked = false;

		}

	}


	
}
