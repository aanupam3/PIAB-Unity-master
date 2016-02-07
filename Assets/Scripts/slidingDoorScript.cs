using UnityEngine;
using System.Collections;

public class slidingDoorScript : MonoBehaviour {

	// Use this for initialization
	public static bool doorOpen1 = false;
	float speed = 0.005f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(doorOpen1)
		{

			if(transform.position.x<-1.53f)
			{
				GameObject.Find("Pulley").transform.Rotate(0,0,1f);
				gameObject.transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			}
				
		}

	
	}

}
