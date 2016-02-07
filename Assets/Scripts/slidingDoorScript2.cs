using UnityEngine;
using System.Collections;

public class slidingDoorScript2 : MonoBehaviour {

	// Use this for initialization
	public static bool doorOpen2 = false;
	float speed = 0.01f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(doorOpen2)
		{
			
			if(transform.position.y>-1.53f)
			{

				GameObject.Find("PulleyTutorial").transform.Rotate(0,0,1f);
				gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - speed);
			}
				

		}

		if(GameObject.FindGameObjectWithTag("Player").transform.position.x>-5f)
		{
			if(transform.position.y<-0.55f)
				gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 10*speed);
			doorOpen2 = false;
		}
	
	}

}
