using UnityEngine;
using System.Collections;

public class MeasurementLineScript : MonoBehaviour {

	// Use this for initialization
	GameObject measurementText, particle;
	TutManagerQ1 tutManager;
	float lineTop = 1f;
	void Start () 
	{
		tutManager = GameObject.Find("TutorialManager").GetComponent<TutManagerQ1>();
		particle = GameObject.FindGameObjectWithTag("Particle");

//		measurementText = tutManager.CreateText(new Vector3(particle.transform.position.x,lineTop,particle.transform.position.z),"Measurement");
//		measurementText.transform.parent = gameObject.transform;
//		measurementText.name = "Measurement Text";
	
	}
	
	// Update is called once per frame
	void Update () {
		
//		
		if(qParticleScript.hold)
		{
			Animator textAnim = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
			GetComponent<LineRenderer>().SetPosition(0,new Vector3(particle.transform.position.x, particle.transform.position.y,0));
			GetComponent<LineRenderer>().SetPosition(1,new Vector3(particle.transform.position.x, lineTop,0));
			transform.GetChild(0).gameObject.transform.position = new Vector3(particle.transform.position.x, lineTop,0);
//			measurementText.transform.position = new Vector3(particle.transform.position.x,lineTop,particle.transform.position.z);
		}
//		
//			gameObject.transform.GetChild(0).GetChild(0).transform.position = new Vector3(particle.transform.position.x, 1f,0);
//			textAnim.SetTrigger("textFadeIn");
//			MakeTrail();
	
	}

}
