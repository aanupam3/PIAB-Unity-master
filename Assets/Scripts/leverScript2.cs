using UnityEngine;
using System.Collections;

public class leverScript2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Particle")
		{
			gameObject.GetComponent<Animator>().SetBool("leverOn",true);

			slidingDoorScript2.doorOpen2 = true;
			//tutorialManager.i++;

		}
		
	}
}
