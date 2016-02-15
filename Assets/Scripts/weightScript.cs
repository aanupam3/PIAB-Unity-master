using UnityEngine;
using System.Collections;

public class weightScript : MonoBehaviour {

	// Use this for initialization
	Animator animator;
	float oscillate = 0;
	bool increase = true;
	GameObject player, spawn;
	public bool picked = false;
	int flag=0;
	Vector2 initPosition;
	void Start () {
		initPosition = gameObject.transform.position;
		flag =0;
		animator = gameObject.GetComponent<Animator>();
		player =  (GameObject)GameObject.Find("PlayerQ");
		spawn=  GameObject.FindGameObjectWithTag("Spawn");
//		spawn.transform.position = new Vector3(-4.51f,-0.58f,0);

	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(oscillate >=0.01f)
		increase = false;
		
		if(oscillate<=-0.01f)
			increase = true;
		
		gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+oscillate);
		
		if(increase)
			oscillate = oscillate + 0.0007f;
		else
			oscillate = oscillate - 0.0007f;

		flag = 1;
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
