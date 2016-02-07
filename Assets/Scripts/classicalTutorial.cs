using UnityEngine;
using System.Collections;
using Vectrosity;

public class classicalTutorial : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		VectorLine.canvas.renderMode = RenderMode.WorldSpace;
		VectorLine.canvas.transform.position = new Vector2(VectorLine.canvas.transform.position.x-0.5f,VectorLine.canvas.transform.position.y-0.5f);

	}
	void Start () {

		//VectorLine.SetCamera3D();
		//Vector2[] linePoints = {new Vector2(0,0),new Vector2(1,1)};
		//VectorLine myline = new VectorLine.SetLine(Color.green, new Vector2(0, 0), new Vector2(1, 1));
		Vector2[] linePoints = { new Vector2(0, 0),new Vector2(1, 1)};
		Material line = (Material)Resources.Load("Line");
		VectorLine myline = new VectorLine("MyLine",linePoints,null,0.05f,LineType.Continuous);
		//VectorLine.SetCanvasCamera (Camera.main);


		//c.re

		Rect r = new Rect(0,0,2,1);
		//myline.make
		myline.MakeRoundedRect(r, 0.2f,10);
		myline.SetColor(Color.black);

		myline.Draw();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
