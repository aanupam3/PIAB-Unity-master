//using UnityEngine;
//using UnityEngine.UI;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//
//namespace TutorialUtilies
//{
//	public class Tutilities : MonoBehaviour 
//	{
//
//		// Use this for initialization
//		int flag, flagAction, flagSimu;
//		GameObject BubbleText;
//		TextMesh bTMesh;
//		GameObject next,back;
//		int bTlength = 60; //Text wrapping length for instruction Box
//		Action[] a;
//		int aCounter;
//		bool makeTrail, fallingDone, gotOneWeight;
//		float fadeInc = 0.01f;
//		List<GameObject> hideObjects, showObjectsAllNexts; 
//		GameObject player;
//		void Start () {
//		
//		}
//		
//		// Update is called once per frame
//		void Update () {
//		
//		}
//
//		//------------------------------OnClick related---------------------------------
//
//
//		//------------------------------HIDE and SHOW FUNCTIONS-------------------------------
//
//		public static void Hide(GameObject g)
//		{
//			if(g.GetComponent<SpriteRenderer>()!=null)
//			{
//				SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
//				sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,0);
//			}
//			if(g.GetComponent<LineRenderer>()!=null)
//			{
//				LineRenderer lr = g.GetComponent<LineRenderer>();
//				lr.enabled = false;
//			}
//			if(g.GetComponentInChildren<Canvas>()!=null)
//			{
//				g.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().enabled = false;
//			}
//
//		}
//		public static void HideList()
//		{
//			hideObjects.Add(GameObject.Find("QweightGreen"));
//			hideObjects.Add(GameObject.Find("QweightBlue"));
//			hideObjects.Add(GameObject.Find("QweightRed"));
//			hideObjects.Add(GameObject.Find("WaveProbability"));
//			hideObjects.Add(GameObject.Find("LightSource"));
//			hideObjects.Add(GameObject.Find("Energy_Levels_Overlay_Quantum"));
//			hideObjects.Add(GameObject.Find("electron"));
//			hideObjects.Add(GameObject.Find("MeasurementLine"));
//			hideObjects.Add(GameObject.Find("PotentialProfile"));
//			hideObjects.Add(GameObject.Find("WellWallL"));
//			hideObjects.Add(GameObject.Find("WellWallR"));
//			hideObjects.Add(GameObject.Find("PsiCalc"));
//			hideObjects.Add(GameObject.Find("Wave_Function_Overlay"));
//			foreach(Transform t in GameObject.Find("EnergyLevels").transform)
//			{
//				hideObjects.Add(t.gameObject);
//			}
//			//		foreach(Transform t in GameObject.Find("EnergyLabels").transform)
//			//		{
//			//			hideObjects.Add(t.gameObject);
//			//		}
//
//		}
//		public static void HideAll()
//		{
//			foreach(GameObject h in hideObjects)
//			{
//				Hide(h);
//			}
//			GameObject[] Tarrows = GameObject.FindGameObjectsWithTag("TArrow");
//
//			foreach(GameObject t in Tarrows)
//			{
//				Destroy(t.gameObject);
//			}
//
//			GameObject[] dummies = GameObject.FindGameObjectsWithTag("dummyG");
//			foreach(GameObject t in dummies)
//			{
//				Destroy(t.gameObject);
//			}
//
//		}
//		public static void Show(GameObject g)
//		{
//			if(g.GetComponent<SpriteRenderer>()!=null)
//			{
//				SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
//
//				for(float i=0;i<1;i+=fadeInc)
//				{
//					sr.color = Color.Lerp(new Color(sr.color.r,sr.color.g,sr.color.b,0),new Color(sr.color.r,sr.color.g,sr.color.b,1),i);
//				}
//			}
//			if(g.GetComponent<LineRenderer>()!=null)
//			{
//				LineRenderer lr = g.GetComponent<LineRenderer>();
//				//			for(float i=0;i<1;i+=inc)
//				//				lr.SetColors(new Color(
//				lr.enabled = true;
//			}
//			if(g.GetComponentInChildren<Canvas>()!=null)
//			{
//				g.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().enabled = true;
//			}
//
//		}
//		public static void ShowForAllNexts(GameObject g)
//		{
//			Show(g);
//			hideObjects.Remove(g);
//		}
//
//
//		//------------------------------Fading------------------------------------------------
//		//	IEnumerator FadeIn(SpriteRenderer r)
//		//	{
//		//		float fadespeed = 0.1f;
//		//		r.color = new Color(r.color.r,r.color.g,r.color.b,Mathf.Lerp(0,1,Time.deltaTime * fadespeed));
//		//		yield return null;
//		//
//		//	}
//
//		//------------------------------Arrow and Text Functions-------------------------------
//
//		/** Creates an arrow at the specified location and angle(degrees), 0 degrees means default sprite direction.*/
//		public GameObject CreateArrow(Vector3 location, float Angle, Sprite sp =null)
//		{
//			GameObject arrow =  new GameObject();
//			arrow.AddComponent<SpriteRenderer>();
//			SpriteRenderer arrowSR = arrow.GetComponent<SpriteRenderer>();
//
//			if(sp==null)
//			{
//				if(Application.loadedLevelName=="Quantum1")
//					arrowSR.sprite = Resources.Load<Sprite>("QArrow");
//				else if(Application.loadedLevelName=="classical")
//					arrowSR.sprite = Resources.Load<Sprite>("CArrow");
//			}
//			else
//				arrowSR.sprite = sp;
//			arrow.name = "Arrow";
//			float scale = 0.3160167f;
//			arrow.transform.localScale = new Vector3(scale,scale,scale);
//			arrow.transform.Rotate(Vector3.forward,Angle);
//			arrow.transform.position = new Vector3(location.x,location.y,location.z);
//			//		FadeIn(arrowSR);
//			for(float i=0;i<1;i+=fadeInc)
//			{
//				//			arrowSR.material.color = Color.Lerp(new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,0),new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,1),i);
//				arrowSR.color = Color.Lerp(new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,0),new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,1),i);
//			}
//			return arrow;
//		}
//		/** Creates the input text at the specified location. 
//	 * Default font: Gill Sans
//	 * Default color: White */
//		public GameObject CreateText(Vector3 location, String texter)
//		{
//			GameObject textBox =  new GameObject();
//			textBox.name = "Text:" + texter;
//			textBox.transform.position = location;
//			GameObject canvas = (GameObject)Instantiate(Resources.Load("Canvas"));
//			canvas.transform.parent = textBox.transform;
//			canvas.transform.position = textBox.transform.position;
//			Text words = canvas.GetComponentInChildren<Text>();
//			words.text = texter;
//			return textBox;
//		}
//		/** Creates an arrow depending on level with orientation: "up","down","left","right" and 
//	 * offset by a shift with the gameobject depending on the gameobject sprite size.*/
//		public GameObject CreateArrowG(GameObject g, String orientation = "down", Sprite sp =null)
//		{
//			Vector3 location;
//			float extent;
//			location = g.transform.position;
//			if(g.GetComponent<SpriteRenderer>()!=null)
//			{
//				if(orientation.ToLower() == "up" || orientation.ToLower() == "down")
//					extent = Mathf.Abs(g.GetComponent<SpriteRenderer>().bounds.size.y);
//				else
//					extent = Mathf.Abs(g.GetComponent<SpriteRenderer>().bounds.size.x);
//			}
//			else
//				extent = 0.3f;
//
//			float angle=0;
//			if(orientation.ToLower() == "up")
//			{
//
//				location = new Vector3(location.x,location.y-extent,location.z);
//				angle = 180;
//			}
//			else if(orientation.ToLower() == "down")
//			{
//
//				location = new Vector3(location.x,location.y+extent,location.z);
//				angle =0;
//			}
//			else if(orientation.ToLower() == "right")
//			{
//
//				location = new Vector3(location.x-extent,location.y,location.z);
//				angle = 90;
//			}
//			else if(orientation.ToLower() == "left")
//			{
//
//				location = new Vector3(location.x+extent,location.y,location.z);
//				angle =-90;
//			}
//			else
//			{
//				Debug.LogError("No matching arrow orientation");
//			}
//
//			return CreateArrow(location,angle, sp);
//		}
//
//		/** Creates a text depending on level with orientation: "up","down","left","right" and 
//	 * offset by a shift with the gameobject depending on the gameobject sprite size.*/
//		public GameObject CreateTextG(GameObject g, String texter, String orientation = "down")
//		{
//			Vector3 extent, location;
//			location = g.transform.position;
//			if(g.GetComponent<SpriteRenderer>()!=null)
//				extent = (2f/3)*g.GetComponent<SpriteRenderer>().bounds.size;
//			else
//				extent = new Vector3(0.3f,0.3f,0);
//
//			if(orientation.ToLower() == "up")
//				location = new Vector3(location.x,location.y-1.2f*extent.y,location.z);
//			else if(orientation.ToLower() == "down")
//				location = new Vector3(location.x,location.y+extent.y,location.z);
//			else if(orientation.ToLower() == "right")
//				location = new Vector3(location.x-extent.x,location.y,location.z);
//			else if(orientation.ToLower() == "left")
//				location = new Vector3(location.x+extent.y,location.y,location.z);
//			else
//				Debug.LogError("No matching text orientation");
//
//			return CreateText(location, texter);
//
//		}
//		/** Creates a combined Text and arrow set with correct spacing with respect to a given gameobject and 
//	 * with the specified pointing orientation. */
//		public GameObject CreateTextArrow(GameObject g, String texter, String orientation = "down", Sprite sp =null)
//		{
//			GameObject arrow = CreateArrowG(g,orientation);
//			GameObject textArrow = CreateTextG(arrow,texter,orientation);
//			arrow.transform.parent = textArrow.transform;
//			textArrow.tag = "TArrow";
//			return textArrow;
//		}
//		/** Creates a combined Text and arrow set with correct spacing with respect to a given gameobject, the shift from it and 
//	 * with the specified pointing orientation. */
//		public GameObject CreateTextArrow(GameObject g, Vector3 shift, String texter, String orientation = "down", Sprite sp =null)
//		{
//			Vector3 shifter = g.transform.position+shift;
//			GameObject dummyShiftedG = new GameObject();
//			dummyShiftedG.tag = "dummyG";
//			dummyShiftedG.transform.position = shifter;
//			GameObject arrow = CreateArrowG(dummyShiftedG,orientation);
//			GameObject textArrow = CreateTextG(arrow,texter,orientation);
//			arrow.transform.parent = textArrow.transform;
//			textArrow.tag = "TArrow";
//			return textArrow;
//		}
//		/** Creates a combined Text and arrow set with correct spacing with respect to a given arrow location and 
//	 * with the specified pointing orientation. */
//		public GameObject CreateTextArrow(Vector3 location, String texter, String orientation = "down", Sprite sp =null)
//		{
//			GameObject g = new GameObject();
//			g.transform.position = location;
//			GameObject arrow = CreateArrowG(g,orientation,sp);
//			GameObject textArrow = CreateTextG(arrow,texter,orientation);
//			arrow.transform.parent = textArrow.transform;
//			g.transform.parent = textArrow.transform;
//			textArrow.tag = "TArrow";
//			return textArrow;
//		}
//		/** Creates a combined Text and arrow set with correct spacing with respect to a given text and arrow location and 
//	 * angle. */
//		public GameObject CreateTextArrow(Vector3 arrowLocation, Vector3 textLocation, float Angle, String texter, Sprite sp =null)
//		{
//			GameObject arrow = CreateArrow(arrowLocation,Angle,sp);
//			GameObject textArrow = CreateText(textLocation,texter);
//			arrow.transform.parent = textArrow.transform;
//			textArrow.tag = "TArrow";
//			return textArrow;
//		}
//		//-----------------------------------Other functions-------------------------------------
//		private string ResolveTextSize(string input, int lineLength){
//
//			// Split string by char " "         
//			string[] words = input.Split(" "[0]);
//
//			// Prepare result
//			string result = "";
//
//			// Temp line string
//			string line = "";
//
//			// for each all words        
//			foreach(string s in words){
//				// Append current word into line
//				string temp = line + " " + s;
//
//				// If line length is bigger than lineLength
//				if(temp.Length > lineLength){
//
//					// Append current line into result
//					result += line + "\n";
//					// Remain word append into new line
//					line = s;
//				}
//				// Append current word into current line
//				else {
//					line = temp;
//				}
//			}
//
//			// Append last line into result        
//			result += line;
//
//			// Remove first " " char
//			return result.Substring(1,result.Length-1);
//		}
//		public static void MakeTrail()
//		{
//
//			GameObject particle = GameObject.FindGameObjectWithTag("Particle");
//			GameObject clone = new GameObject();
//			clone.AddComponent<SpriteRenderer>();	
//			Color c = new Color (255,255,255,0.02f);
//			clone.GetComponent<SpriteRenderer>().color = c;
//			clone.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("electron");
//
//			clone.transform.position = new Vector2(particle.transform.position.x, particle.transform.position.y);
//			clone.transform.localScale = particle.transform.localScale;
//			clone.transform.parent = GameObject.Find ("Trail").transform;
//
//
//		}
//		public static void ButtonEnable(GameObject g)
//		{
//			g.GetComponent<Button>().interactable = true;
//			Color c = new Color(1,1,1,1);
//			ColorBlock cb = g.GetComponent<Button>().colors;
//			g.GetComponent<Image>().color = c;
//			cb.normalColor = c;
//			g.GetComponent<Button>().colors = cb;
//		}
//		public static void ButtonDisable(GameObject g)
//		{
//			g.GetComponent<Button>().interactable = false;
//
//			Color c = new Color(0,0,0,0);
//			ColorBlock cb = g.GetComponent<Button>().colors;
//			g.GetComponent<Image>().color = c;
//			cb.normalColor = c;
//			g.GetComponent<Button>().colors = cb;
//		}
//		//	IEnumerator FadeIn(Renderer rend)
//		//	{
//		//		float f = 0.0f; 
//		//
//		//		rend.enabled = true; 
//		//		rend.material.color = Color.clear; 
//		////		scoreText.renderer.material.color = Color.clear; 
//		////		scoreText.renderer.enabled = true; 
//		//
//		//		while (f < 1.0f)
//		//		{
//		//			yield return null; 
//		//			f += Time.deltaTime; 
//		//			rend.material.color = new Color(1,1,1, Mathfx.Hermite (0, 1, f) ); 
//		//			scoreText.renderer.material.color = new Color(1,1,1, Mathfx.Hermite (0, 1, f) ); 
//		//		}
//		//
//		//		rend.material.color = Color.white; 
//		//	}
//	}
//}