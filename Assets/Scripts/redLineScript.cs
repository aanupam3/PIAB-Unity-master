using UnityEngine;
using System.Collections;

public class redLineScript : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRenderer;
	GameObject TE, PE, particle, redline;
	RaycastHit2D rcast;
	void Start () {

		foreach (Transform g in transform)
		{
			if(g.tag == "TE")
				TE = g.gameObject;
			if(g.tag == "PE")
				PE = g.gameObject;
			if(g.tag == "RedLine")
				redline = g.gameObject;
			if(g.tag == "Particle")
				particle = g.gameObject;
			//Debug.Log (g);
		}
		lineRenderer = redline.GetComponent<LineRenderer>();
		Material m = (Material)Resources.Load("Line");
		lineRenderer.material = m;
		lineRenderer.SetColors(new Color(1,0,0,0.8f),new Color(1,0,0,0.8f));
		lineRenderer.SetWidth(0.02f,0.02f);
		//lineRenderer.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{


		lineRenderer.SetPosition(0, new Vector3(particle.transform.position.x,TE.transform.position.y,0));
		rcast = Physics2D.Raycast(new Vector2(particle.transform.position.x,TE.transform.position.y-0.2f),new Vector2(0,-1));

		//Debug.Log (rcast.transform.name);
		if(rcast.transform.tag == "Particle")
			lineRenderer.SetPosition(1, new Vector3(particle.transform.position.x,TE.transform.position.y,0));
		else
			lineRenderer.SetPosition(1, new Vector3(particle.transform.position.x,rcast.point.y,0));

	
	}
}
