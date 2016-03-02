using UnityEngine;
using System.Collections;

public class weightScript2 : MonoBehaviour {

	// Use this for initialization
	float oscillate = 0;
	bool increase = true;
	Animator animator;
	GameObject player, spawn;
	bool picked = false;
	int flag =0;
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		player =  (GameObject)GameObject.Find("Player");
		spawn=  GameObject.FindGameObjectWithTag("Spawn");

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
		flag =1;
//		Debug.Log(player.transform.position);
//		gameObject.transform.position = player.transform.position;
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

		if(other.tag == "Particle")
		{
			Destroy(gameObject);
			playerController.score += 1000;
//			Debug.Log(playerController.score);
			other.GetComponent<BallMotion>().TE += 6f;
			picked = false;
			other.GetComponent<Animator>().SetTrigger("ballShine");

		}

		if(picked)
		{
			gameObject.transform.position = player.transform.position;
//			Debug.Log(gameObject.transform.position);
		}

		if(playerController.dead)
		{
			picked = false;

		}

	}


	
}
