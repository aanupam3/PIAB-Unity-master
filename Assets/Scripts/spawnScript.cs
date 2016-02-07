using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour {

	// Use this for initialization

	//GameObject spawn;
	GameObject lightSource;
	void Start () {
//		gameObject.transform.position = new Vector2(4.67f,-0.95f);
		lightSource = GameObject.FindGameObjectWithTag("LightSource");
		GetComponent<Animator>().SetBool("spawnActive",false);
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(lightSource.GetComponent<lightSourceScript>().weightsCollected == lightSource.GetComponent<lightSourceScript>().totalWeights)
		{
			GetComponent<Animator>().SetBool("spawnActive",true);
		}


	}

	void OnTriggerStay2D(Collider2D other) 
	{
		if(other.tag == "Player" && lightSource.GetComponent<lightSourceScript>().weightsCollected == lightSource.GetComponent<lightSourceScript>().totalWeights)
		{

			Application.LoadLevel(Application.loadedLevel+1);

		}
	}

}
