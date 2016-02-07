using UnityEngine;
using System.Collections;

public class arrowMotion : MonoBehaviour {

	// Use this for initialization
	float oscillate = 0;
	bool increase = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(oscillate >=0.01f)
			increase = false;
		
		if(oscillate<=-0.01f)
			increase = true;
		

		//Debug.Log(oscillate);
		if(name == "Arrow2a")
		{
			gameObject.transform.position = new Vector2(gameObject.transform.position.x,GameObject.Find ("TotalEnergyTutorial").transform.position.y + 0.3f +oscillate);
		}
		if(name == "Arrow4")
		{
			gameObject.transform.position = new Vector2(gameObject.transform.position.x,GameObject.Find ("TotalEnergyTutorial").transform.position.y - 0.2f);
		}

		if(name == "Arrow6")
		{
			gameObject.transform.position = new Vector2(gameObject.transform.position.x+oscillate,gameObject.transform.position.y);
		}
		else
			gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+oscillate);

		if(name == "Arrow8a")
		{
			GameObject particle = GameObject.Find ("Particle (1)");
			//LineRenderer rlTline = redLineT.GetComponent<LineRenderer>();
			gameObject.transform.position = new Vector2(particle.transform.position.x- 0.4f,GameObject.Find ("RedLineTutorial").transform.position.y-0.45f);
		}

//		if(increase)
//			oscillate = oscillate + 0.0007f;
//		else
//			oscillate = oscillate - 0.0007f;

	}
}
