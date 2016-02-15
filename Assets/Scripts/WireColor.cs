using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WireColor : MonoBehaviour {

	// Use this for initialization
	Gradient g = new Gradient();
	GradientAlphaKey[] gak;
	GradientColorKey[] gck;
	Mesh m;
	float[] probM; 
	public bool probSignal;
	Vector3[] vertices;
	Color[] colors;
	LineRenderer lineRendererV; 
	GameObject[] lineSegments;
	void Start ()
	{
		probM = PsiCalc.probM;
		lineSegments = new GameObject[probM.Length];
		probSignal = true;
	}
	void Update ()
	{
		if(probSignal)
		{
//			Debug.Log("Plot Wire");
			wirePlot();
			probSignal = false;
		}
		
	}
	void wirePlot()
	{
		probM = PsiCalc.probM;
		if(lineSegments.Length!=0)
		{
			for(int i=0;i<lineSegments.Length;i++)
			{
				Destroy(lineSegments[i]);
			}
		}
		float x = PsiCalc.xmin;
		int num_points = probM.Length;
//		lineRendererV.SetVertexCount(num_points);

		probM = PsiCalc.probM;
		float probMax = Mathf.Max(probM);
		for(int j=0;j<num_points-1;j++)
		{
			lineSegments[j] = new GameObject();
			lineSegments[j].transform.parent = gameObject.transform;
			lineSegments[j].AddComponent<LineRenderer>();
		}

		for(int j=0;j<num_points-1;j++)
		{
//			lineRendererV[j].SetColors
			//37, 216, 221
			float r1 = (37f/255);
			float g1 = 216f/255;
			float b1 = 221f/255;
			float r2 = 178f/255;
			float g2 = 198f/255;
			float b2 = 69f/255;
			lineRendererV = lineSegments[j].GetComponent<LineRenderer>();
			lineRendererV.material = (Material)Resources.Load("Line");
			lineRendererV.SetWidth(0.04f,0.04f);

			lineRendererV.SetPosition(0, new Vector3(x,-1.628f,0));
			lineRendererV.SetPosition(1, new Vector3(x + PsiCalc.dx,-1.628f,0));
			float del_r = r1*(1-(probM[j]/probMax)) + r2*(probM[j]/probMax);
//			Debug.Log(r1*(probM[j]/probMax));
			float del_g = g1*(1-(probM[j]/probMax)) + g2*(probM[j]/probMax);
			float del_b = b1*(1-(probM[j]/probMax)) + b2*(probM[j]/probMax);
			Color c = new Color (del_r,del_g,del_b);
//			Debug.Log(c);
			lineRendererV.SetColors(c,c);
			x = x + PsiCalc.dx;

		}
		//gameObject.GetComponentsInChildren<LineRenderer>()[1].SetPosition(0, new Vector3(-4,5,0));
//		gameObject.GetComponentsInChildren<LineRenderer>()[1].SetPosition(1, new Vector3(-4,PsiCalc.yOffset,0));
//		gameObject.GetComponentsInChildren<LineRenderer>()[2].SetPosition(1, new Vector3(4,PsiCalc.yOffset,0));

	}
//		probM = new float[Mathf.FloorToInt(PsiCalc.probM.Length/10.0f)];

//		for(int p=0;p<probM.Length;p++)
//		{
//			Debug.Log (probM[p]);
//		}

//		m = GetComponent<MeshFilter>().mesh;
//		m.Clear();
////		m.vertices = new Vector3[] {new Vector3(-0.5f, -0.5f, 0), new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, -0.5f, 0)};
////		m.uv = new Vector2[] {new Vector2(-0.5f, -0.5f), new Vector2(-0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, -0.5f)};
////		m.triangles = new int[] {0, 1, 2, 1, 2, 3};
//		Vector3 leftEnd = new Vector3(-0.5f,-0.5f,0);
//		Vector3 rightEnd = new Vector3(0.5f,-0.5f,0);
//		Vector3[] newVertices = new Vector3[2*probM.Length];
//		int[] newTriangles = new int[3*newVertices.Length];
//		Vector2[] newUvs = new Vector2[2*probM.Length];
//		float dx = Mathf.Abs((rightEnd.x-leftEnd.x)/probM.Length);
//		int j=0;
//		for(float x=leftEnd.x;x<=rightEnd.x;x+=dx)
//		{
//
//			float y=-0.5f;
//			while(y<=0.5f && j<newVertices.Length)
//			{
//
//				newVertices[j] = new Vector3(x,y);
//				j++;
//				y+=1f;
//			}
//		}
//
//		m.vertices = newVertices;
//		Graphics.DrawMeshNow(m, Matrix4x4.identity);
//		for(float x=leftEnd.x;x<=rightEnd.x;x+=dx)
//		{
//			
//			float y=-0.5f;
//			while(y<=0.5f && j<newVertices.Length)
//			{
//				
//				newUvs[j] = new Vector2(x,y);
//				j++;
//				y+=1f;
//			}
//		}
//		m.uv = newUvs;
//		int index=0;
//		for(int a=0;a<newTriangles.Length-11;)
//		{
//
//			if(index<newVertices.Length)
//			{
////				newTriangles[a] = (index+0);
//////				Debug.Log (newVertices[index+2].x+","+newVertices[index+2].y);
////				newTriangles[a+1] = (index+1);
//////				Debug.Log (newVertices[index].x+","+newVertices[index].y);
////				newTriangles[a+2] = (index+2);
//////				Debug.Log (newVertices[index+2].x+","+newVertices[index+2].y);
////				newTriangles[a+3] = (index+3);
//////				Debug.Log (newVertices[index+3].x+","+newVertices[index+3].y);
////				newTriangles[a+4] = (index);
//////				Debug.Log (newVertices[index].x+","+newVertices[index].y);
////				newTriangles[a+5] = (index+1);
////				Debug.Log (newVertices[index+1].x+","+newVertices[index+1].y);
//				newTriangles[a] = (index + 0);
//				newTriangles[a+1] = (index+1);
//				newTriangles[a+2] = (index+2);
//				newTriangles[a+3] = (index+3);
//				newTriangles[a+4] = (index+0);
//				newTriangles[a+5] = (index+1);
//			}
//			index+=2;
//			a+=6;
////			Debug.Log(newTriangles[a]);
//		}
//		m.triangles = newTriangles;
//
//
//
//		for(int k=0;k<newVertices.Length;k++)
//		{
////			m.triangles[k] = k;
////			Debug.Log(newVertices[k]);
//		}
//		colors = new Color[m.vertices.Length];
//		int i = 0;
//		float probMax = Mathf.Max(probM);
//		//		61,227,244
//		while (i < colors.Length) {
//			//			if(m.vertices[i].x>-0.5f && m.vertices[i].x<=-0.25f)
//			//				colors[i]=new Color(1,0,0);
//			//			else if(m.vertices[i].x>-0.25f && m.vertices[i].x<=0.25f)
//			//				colors[i]=new Color(0,1,0);
//			//			else if(m.vertices[i].x>0.25f && m.vertices[i].x<=0.5f)
//			//				colors[i]=new Color(0,0,1);
//			//			Mathf.Abs(m.vertices[i].x)*2
//			colors[i] = new Color ((probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax));
//
//			i++;
//		}
//		
//		m.colors = colors;
//		probSignal = true;
////		for(int k=0;k<m.vertices.Length;k++)
////		{
////			Debug.Log(m.colors[k]);
////		}

	
//	void Update()
//	{
//		if(probSignal)
//		{
//			colors = new Color[m.vertices.Length];
//			probM = PsiCalc.probM;
//			float probMax = Mathf.Max(probM);
//
//			int i = 0, j=colors.Length-1;
//			while (i < colors.Length) 
//			{
//
//				if(Application.loadedLevelName == "Quantum1a")
//				{
//					colors[j] = new Color ((probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax));
//				}
//				else
//					colors[i] = new Color ((probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax),(probM[Mathf.FloorToInt(i/2)]/probMax));
//
//				i++;
//				j--;
//			}
//			
//			m.colors = colors;
//			probSignal = false;
//		}
//		
//	}
}
	