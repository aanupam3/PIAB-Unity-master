using UnityEngine;
using System.Collections;

public class cameraSizeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Camera.main.orthographicSize = Screen.height;
		Camera.main.orthographicSize = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
