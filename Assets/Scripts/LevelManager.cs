using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Alpha1))
		{
			Application.LoadLevel("classical");
			tutorialManager.i=0;
			tutorialManager.c=0;
			tutorialManager.boltGone=false;
		}
		if(Input.GetKey(KeyCode.Alpha2))
		{
			//Debug.Log ("Daba");
			Application.LoadLevel("Quantum1");
			tutorialManagerQ.i=0;
			tutorialManagerQ.wCol = false;
		}
		if(Input.GetKey(KeyCode.Alpha3))
			Application.LoadLevel("Quantum1a");
	}
	public void StartGame()
	{
		Application.LoadLevel("classical");
	}
}
