using UnityEngine;
using System.Collections;

public class totalEnergyPosition : MonoBehaviour {

	// Use this for initialization
	GameObject TEPlot, PEPlot, redline, particle, overlay;
	//GameObject TE, PE, particle, redline;
	void Start () {
		
		foreach (Transform g in transform)
		{
			if(g.tag == "TE")
				TEPlot = g.gameObject;
			if(g.tag == "PE")
				PEPlot = g.gameObject;
			if(g.tag == "RedLine")
				redline = g.gameObject;
			if(g.tag == "Particle")
				particle = g.gameObject;
			if(g.tag == "Overlay")
				overlay = g.gameObject;
		}
		GetComponentInChildren<BallMotion>().maxHeight = PEPlot.transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {

		float baseHeight = overlay.GetComponent<SpriteRenderer>().bounds.center.y - overlay.GetComponent<SpriteRenderer>().bounds.extents.y - 0.1f;

		TEPlot.transform.position = new Vector2(TEPlot.transform.position.x, baseHeight + GetComponentInChildren<BallMotion>().maxHeight + 0.15f);
		//Debug.Log (baseHeight + GetComponentInChildren<BallMotion>().maxHeight);
	}
}
