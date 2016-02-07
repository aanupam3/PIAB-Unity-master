using UnityEngine;
using System.Collections;

public class WellEntrance : MonoBehaviour {

	// Use this for initialization
	GameObject sF;
	void Start () {
		sF = GameObject.FindGameObjectWithTag("SceneFade");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Particle")
			Destroy(GameObject.FindGameObjectWithTag("Particle"));
		if(other.tag == "Player")
		{
			sF.GetComponent<Animator>().SetBool("fadeIn",false);
			sF.GetComponent<Animator>().SetBool("fadeOut",true);
			StartCoroutine(LevelLoad());
		}
			
	}
	IEnumerator LevelLoad(){
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(Application.loadedLevel+1);
	}
}
