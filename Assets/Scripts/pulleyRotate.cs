using UnityEngine;
using System.Collections;

public class pulleyRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(slidingDoorScript.doorOpen1==true)
			transform.Rotate(0,0,0.01f);
	
	}
}
