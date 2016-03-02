using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
//using TutorialUtilies;

public class TutManagerQ1 : MonoBehaviour {

	// Use this for initialization
	int flag, flagAction, flagSimu;
	GameObject BubbleText;
	TextMesh bTMesh;
	GameObject next,back;
	int bTlength = 60; //Text wrapping length for instruction Box
	Action[] a;
	int aCounter;
	bool makeTrail, fallingDone, gotOneWeight;
	float fadeInc = 0.01f;
	List<GameObject> hideObjects, showObjectsAllNexts; 
	GameObject player;
	void Start () 
	{
		BubbleText = (GameObject)GameObject.Find("Bubble Text");
		next = (GameObject)GameObject.Find("NextButton");
		back = (GameObject)GameObject.Find("BackButton");
		bTMesh = BubbleText.GetComponent<TextMesh>();
		player = (GameObject)GameObject.Find("PlayerQ");

		fallingDone = false;
		hideObjects = new List<GameObject>();
		showObjectsAllNexts = new List<GameObject>();

		flagSimu = 1;
		flag = 2;
		flagAction =1;
		aCounter=-1;
		makeTrail = false;
		gotOneWeight = false;

		List<Action> actions = new List<Action>();
		actions.Add( ()=> Welcome() );
		actions.Add( ()=> ElectronWaveState() );
		actions.Add( ()=> ElectronParticleState() );
		actions.Add( ()=> OneDWire() );
		actions.Add( ()=> SpeedUp() );
		actions.Add( ()=> MaxAmp() );
		actions.Add( ()=> Middle() );
		actions.Add( ()=> Ends() );
		actions.Add( ()=> EqualProbRegions() );
		actions.Add( ()=> PotentialProfile() );
		actions.Add( ()=> EQuantized() );
		actions.Add( ()=> GroundState() );
		actions.Add( ()=> LightSources() );
		actions.Add( ()=> PhotonColour() );
		actions.Add( ()=> GapExplanation() );
		actions.Add( ()=> Aim() );
		actions.Add( ()=> TotalEnergyIncrease() );
		actions.Add( ()=> Node() );
		actions.Add( ()=> RemaningBulbs() );
		actions.Add( ()=> End() );
		actions.Add( ()=> NextLevel() );

//		actions.Add( ()=> Laddu3() );
		a = actions.ToArray();

		next.GetComponent<Button>().onClick.AddListener(()=> onNextClick());
		back.GetComponent<Button>().onClick.AddListener(()=> onBackClick());


	}
	void HideList()
	{
		hideObjects.Add(GameObject.Find("QweightGreen"));
		hideObjects.Add(GameObject.Find("QweightBlue"));
		hideObjects.Add(GameObject.Find("QweightRed"));
		hideObjects.Add(GameObject.Find("WaveProbability"));
		hideObjects.Add(GameObject.Find("LightSource"));
		hideObjects.Add(GameObject.Find("Energy_Levels_Overlay_Quantum"));
		hideObjects.Add(GameObject.Find("electron"));
		hideObjects.Add(GameObject.Find("MeasurementLine"));
		hideObjects.Add(GameObject.Find("PotentialProfile"));
		hideObjects.Add(GameObject.Find("WellWallL"));
		hideObjects.Add(GameObject.Find("WellWallR"));
		hideObjects.Add(GameObject.Find("PsiCalc"));
		hideObjects.Add(GameObject.Find("Wave_Function_Overlay"));
		foreach(Transform t in GameObject.Find("EnergyLevels").transform)
		{
			hideObjects.Add(t.gameObject);
		}


	}
	// Update is called once per frame
	void Update () 
	{
		if(flag==2)
		{
			HideList();
			flag=1;
		}
		if(flag==1)
		{
			HideAll();
			flag=0;
		}

		//Next Click
		if(flagAction==1)
		{
			if(aCounter<a.Length-1)
				aCounter++;
			a[aCounter].Invoke();
			flagAction =0;
		}

		//Back Click
		if(flagAction==-1)
		{
			if(aCounter>0)
				aCounter--;

			a[aCounter].Invoke();
			flagAction =0;

		}

		//Electron trail
		if(makeTrail)
		{
			
			MakeTrail();
		}
		else
		{
			foreach(Transform t in GameObject.Find("Trail").transform)
				Destroy(t.gameObject);
		}

		//Stopping and starting player simulation during tutorial
		if(GameObject.Find("LightSource").GetComponent<lightSourceScript>().weightsCollected==1 && !gotOneWeight)
		{
			ButtonEnable(GameObject.Find("NextButton"));
			onNextClick();
			flagSimu = 0;
			gotOneWeight = true;
		}

		if(flagSimu==0)
		{
			player.GetComponent<Rigidbody2D>().simulated = false;
			player.GetComponent<Animator>().ResetTrigger("Unlock");
			player.GetComponent<Animator>().SetTrigger("Lock");
		}
		if(flagSimu==1)
		{
			player.GetComponent<Rigidbody2D>().simulated = true;
			player.GetComponent<Animator>().SetTrigger("Unlock");
			player.GetComponent<Animator>().ResetTrigger("Lock");
		}
		if(!fallingDone && Time.timeSinceLevelLoad>1f)
		{
			flagSimu = 0;
			fallingDone = true;
		}
		if(GameObject.Find("LightSource").GetComponent<lightSourceScript>().weightsCollected==3)
		{
			onNextClick();
		}

	}

	//---------------------------------ACTIONS-------------------------------
	void Welcome()
	{
		bTMesh.text = ResolveTextSize("Welcome to the quantum world. Things behave very differently here.",bTlength);
	}
	void ElectronWaveState()
	{
		bTMesh.text = ResolveTextSize("This is an electron in its wave state...",bTlength);
		ShowForAllNexts(GameObject.Find("PsiCalc"));
		Vector3 shift = new Vector3(0,-1.4f,0);
		CreateTextArrow(GameObject.Find("PsiCalc"),shift,"Electron Wave Function");
		Hide(GameObject.Find("electron"));
		makeTrail = false;
	}
	void ElectronParticleState()
	{
		bTMesh.text = ResolveTextSize("To see the electron in its particle state, we need to take measurements. At each measurement we can see where the electron had been.",bTlength);
		Show(GameObject.Find("MeasurementLine"));
		GameObject particle = GameObject.Find("electron");
		ShowForAllNexts(particle);
		makeTrail = true;

	}
	void OneDWire()
	{
		bTMesh.text = ResolveTextSize("Notice that the electron only appears along the wire. That's because this is a 1-D quantum wire. This also means you can't jump.",bTlength);
//		Vector3 loc = GameObject.Find("Wire").transform.position;
		Vector3 loc = new Vector3(2f,0,0);
		CreateTextArrow(GameObject.Find("Wire"), loc,"One-Dimensional wire","up");
		Show(GameObject.Find("MeasurementLine"));
		qParticleScript.delay=0.5f;
		qParticleScript.persist=0.3f;
	}
	void SpeedUp()
	{
		bTMesh.text = ResolveTextSize("Let's speed things up a little and see where the electron occurs most.",bTlength);
		qParticleScript.delay=0.05f;
		qParticleScript.persist=0.1f;

	}
	void MaxAmp()
	{
		bTMesh.text = ResolveTextSize("The maximum amplitude of the wave at any point tells us the probability of finding the electron there.",bTlength);
		Show(GameObject.Find("WaveProbability"));
		qParticleScript.delay=0.5f;
		qParticleScript.persist=0.3f;

	}
	void Middle()
	{
		bTMesh.text = ResolveTextSize("So for the current state, the electron has the highest chance of being found in the middle of the wire...",bTlength);
		CreateTextArrow(GameObject.Find("Wire"),"Point of maximum probability");
		Show(GameObject.Find("WaveProbability"));

	}
	void Ends()
	{
		bTMesh.text = ResolveTextSize("...and the least chance at the ends of the wire.",bTlength);
		Show(GameObject.Find("WaveProbability"));
		CreateTextArrow(GameObject.Find("Wire"),"Point of maximum probability");
		Vector3 loc = new Vector3(-3.9f,0,0);
		CreateTextArrow(GameObject.Find("Wire"), loc,"Point of minimum probability");
	}
	void EqualProbRegions()
	{
		bTMesh.text = ResolveTextSize("Each of the highlighted regions has the same total probability of finding the electron along the wire",bTlength);
		Show(GameObject.Find("Wave_Function_Overlay"));
		float shift = 1.5f;
		Vector3 probLabels = new Vector3(-4.52f,-0.93f,0);
		GameObject p = CreateText(probLabels,"Probability:");
		GameObject p1 =CreateText(new Vector3(probLabels.x+shift,probLabels.y,probLabels.z),"1/6");
		GameObject p2 =CreateText(new Vector3(p1.transform.position.x+1.6f,probLabels.y,probLabels.z),"1/6");
		GameObject p3 =CreateText(new Vector3(p2.transform.position.x+1f,probLabels.y,probLabels.z),"1/6");
		GameObject p4 =CreateText(new Vector3(p3.transform.position.x+0.6f,probLabels.y,probLabels.z),"1/6");
		GameObject p5 =CreateText(new Vector3(p4.transform.position.x+0.8f,probLabels.y,probLabels.z),"1/6");
		GameObject p6 =CreateText(new Vector3(p5.transform.position.x+1.4f,probLabels.y,probLabels.z),"1/6");

		p.tag = "dummyG";
		p1.tag = "dummyG";
		p2.tag = "dummyG";
		p3.tag = "dummyG";
		p4.tag = "dummyG";
		p5.tag = "dummyG";
		p6.tag = "dummyG";

	}
	void PotentialProfile()
	{
		bTMesh.text = ResolveTextSize("The shape of the wave function is determined by the potential profile. We will discuss this in a later level.",bTlength);
		makeTrail = false;
		ShowForAllNexts(GameObject.Find("PotentialProfile"));
		ShowForAllNexts(GameObject.Find("Energy_Levels_Overlay_Quantum"));
		ShowForAllNexts(GameObject.Find("WellWallL"));
		ShowForAllNexts(GameObject.Find("WellWallR"));
		Vector3 shift = new Vector3(0.5f,0.7f,0);
		CreateTextArrow(GameObject.Find("PotentialProfile"),shift,"Potential Profile", "up");
	}
	void EQuantized()
	{
		bTMesh.text = ResolveTextSize("The electron's Total Energy is quantized in this world, which means it can only have discrete values.",bTlength);
		foreach(Transform t in GameObject.Find("EnergyLevels").transform)
		{
			ShowForAllNexts(t.gameObject);
		}
	}
	void GroundState()
	{
		bTMesh.text = ResolveTextSize("The electron is currently on the ground state (Energy Level 0, coloured in Cyan). Note, this is currently higher than the Potential profile",bTlength);
		Vector3 shift = new Vector3(0,0,0);
		CreateTextArrow(GameObject.Find("E0"),shift,"Ground State", "up");
		Vector3 shift2 = new Vector3(0.5f,0.7f,0);
		CreateTextArrow(GameObject.Find("PotentialProfile"),shift2,"Potential Profile", "up");
	}
	void LightSources()
	{
		bTMesh.text = ResolveTextSize("These are sources of light. When brought to a light machine, they emit photons. Photons can give energy to the electron.",bTlength);
		ShowForAllNexts(GameObject.Find("QweightRed"));
		ShowForAllNexts(GameObject.Find("QweightBlue"));
		ShowForAllNexts(GameObject.Find("QweightGreen"));
	}
	void PhotonColour()
	{
		bTMesh.text = ResolveTextSize("The color of the bulb/photon determines its energy. Lower wavelength (like blue and violet) means higher energy and vice-versa.",bTlength);

		CreateTextArrow(GameObject.Find("QweightBlue"), "Highest Energy");
		CreateTextArrow(GameObject.Find("QweightGreen"), "Middle Energy");
		CreateTextArrow(GameObject.Find("QweightRed"), "Lowest Energy");
//		Sprite[] eArrows = Resources.Load


		//
	}
	void GapExplanation()
	{
		bTMesh.text = ResolveTextSize("These different energies correspond to the energy gaps between the energy level",bTlength);
		CreateTextArrow(GameObject.Find("QweightBlue"), "Highest Energy");
		CreateTextArrow(GameObject.Find("QweightGreen"), "Middle Energy");
		CreateTextArrow(GameObject.Find("QweightRed"), "Lowest Energy");

		float highY = (GameObject.Find("E3").transform.position.y + GameObject.Find("E2").transform.position.y)/2;
		float midY = (GameObject.Find("E2").transform.position.y + GameObject.Find("E1").transform.position.y)/2;
		float lowY = (GameObject.Find("E1").transform.position.y + GameObject.Find("E0").transform.position.y)/2;
		float xShift = 0.8f;
		float xTextShift = 0.8f;
		float yTextShift = -0.1f;
		float x = GameObject.Find("E3").transform.position.x+xShift;

		Sprite[] eArrows = Resources.LoadAll<Sprite>("EnergyArrow");
		Vector3 highAV = new Vector3(x,highY,0);
		Vector3 midAV = new Vector3(x,midY,0);
		Vector3 lowAV = new Vector3(x,lowY,0);

		Vector3 highTextV = new Vector3(highAV.x+xTextShift,highAV.y+yTextShift,highAV.z);
		Vector3 midTextV = new Vector3(midAV.x+xTextShift,midAV.y+yTextShift,midAV.z);
		Vector3 lowTextV = new Vector3(lowAV.x+xTextShift,lowAV.y+yTextShift,lowAV.z);
		
		CreateTextArrow(highAV,highTextV,0,"Highest Energy Gap",eArrows[0]);
		CreateTextArrow(midAV,midTextV,0,"Middle Energy Gap",eArrows[1]);
		CreateTextArrow(lowAV,lowTextV,0,"Lowest Energy Gap",eArrows[2]);
		ButtonEnable(GameObject.Find("NextButton"));
		if(!gotOneWeight)
		{
			flagSimu = 0;
		}
	}
	void Aim()
	{
		bTMesh.text = ResolveTextSize("Your aim is to increase the electron's energy from Energy Level 0 (ground state) to the highest state (Energy level 3) here. Bring the light bulb corresponding to the first energy gap to the light machine.",bTlength);

		ShowForAllNexts(GameObject.Find("LightSource"));
		CreateTextArrow(GameObject.Find("LightSource"),"Light Machine");

		float highY = (GameObject.Find("E3").transform.position.y + GameObject.Find("E2").transform.position.y)/2;
		float midY = (GameObject.Find("E2").transform.position.y + GameObject.Find("E1").transform.position.y)/2;
		float lowY = (GameObject.Find("E1").transform.position.y + GameObject.Find("E0").transform.position.y)/2;
		float xShift = 0.8f;
		float xTextShift = 0.8f;
		float yTextShift = -0.1f;
		float x = GameObject.Find("E3").transform.position.x+xShift;

		Sprite[] eArrows = Resources.LoadAll<Sprite>("EnergyArrow");
		Vector3 highAV = new Vector3(x,highY,0);
		Vector3 midAV = new Vector3(x,midY,0);
		Vector3 lowAV = new Vector3(x,lowY,0);

		Vector3 highTextV = new Vector3(highAV.x+xTextShift,highAV.y+yTextShift,highAV.z);
		Vector3 midTextV = new Vector3(midAV.x+xTextShift,midAV.y+yTextShift,midAV.z);
		Vector3 lowTextV = new Vector3(lowAV.x+xTextShift,lowAV.y+yTextShift,lowAV.z);

		CreateTextArrow(highAV,highTextV,0,"Highest Energy Gap",eArrows[0]);
		CreateTextArrow(midAV,midTextV,0,"Middle Energy Gap",eArrows[1]);
		CreateTextArrow(lowAV,lowTextV,0,"Lowest Energy Gap",eArrows[2]);

		if(!gotOneWeight)
		{
			ButtonDisable(GameObject.Find("NextButton"));
			flagSimu = 1;
		}


	}
	void TotalEnergyIncrease()
	{
		bTMesh.text = ResolveTextSize("The Total Energy has increased. The wavefunction changes for each energy level, so it now looks different.",bTlength);
		Vector3 shift1 = new Vector3(2f,-0.01f,0);
		CreateTextArrow(GameObject.Find("E1"),shift1,"Total Energy has increased");
		Vector3 shift2 = new Vector3(2f,-1f,0);
		CreateTextArrow(GameObject.Find("PsiCalc"),shift2,"New Wavefunction");
	}
	void Node()
	{
		bTMesh.text = ResolveTextSize("It now has a node, a point where the electron has zero probability of appearing. The number of nodes is equal to the energy level number. It also has new points of maximum probability",bTlength);
		Vector3 shift1 = new Vector3(2f,0,0);
		CreateTextArrow(GameObject.Find("Wire"),shift1,"Point of maximum probability");
		Vector3 shift2 = new Vector3(-2f,0,0);
		CreateTextArrow(GameObject.Find("Wire"),shift2,"Point of maximum probability");
//		Vector3 shift2 = new Vector3(0,0,0);
		CreateTextArrow(GameObject.Find("Wire"),"Node");
		ButtonEnable(GameObject.Find("NextButton"));
	}
	void RemaningBulbs()
	{
		bTMesh.text = ResolveTextSize("Get the remaining photons to finish the level. Press next to play.", bTlength);

	}
	void End()
	{
		flagSimu = 1;
		Destroy(GameObject.Find("instruction bubble"));
		ButtonDisable(GameObject.Find("BackButton"));
		ButtonDisable(GameObject.Find("NextButton"));
		bTMesh.text = "";

	}
	void NextLevel()
	{
		Vector3 shift1 = new Vector3(0,0.1f,0);
		CreateTextArrow(GameObject.Find("spawnQ"),shift1,"Next Level");
	}

//	//------------------------------OnClick related---------------------------------
	void onNextClick()
	{
		flagAction=1;
		flag=1;
	}
	void onBackClick()
	{
		flagAction=-1;
		flag=1;
	}
//
//	//------------------------------HIDE and SHOW FUNCTIONS-------------------------------

	void Hide(GameObject g)
	{
		if(g.GetComponent<SpriteRenderer>()!=null)
		{
			SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
			sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,0);
		}
		if(g.GetComponent<LineRenderer>()!=null)
		{
			LineRenderer lr = g.GetComponent<LineRenderer>();
			lr.enabled = false;
		}
		if(g.GetComponentInChildren<Canvas>()!=null)
		{
			g.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().enabled = false;
		}

	}

	void HideAll()
	{
		foreach(GameObject h in hideObjects)
		{
			Hide(h);
		}
		GameObject[] Tarrows = GameObject.FindGameObjectsWithTag("TArrow");

		foreach(GameObject t in Tarrows)
		{
			Destroy(t.gameObject);
		}

		GameObject[] dummies = GameObject.FindGameObjectsWithTag("dummyG");
		foreach(GameObject t in dummies)
		{
			Destroy(t.gameObject);
		}

	}
	void Show(GameObject g)
	{
		if(g.GetComponent<SpriteRenderer>()!=null)
		{
			SpriteRenderer sr = g.GetComponent<SpriteRenderer>();

			for(float i=0;i<1;i+=fadeInc)
			{
				sr.color = Color.Lerp(new Color(sr.color.r,sr.color.g,sr.color.b,0),new Color(sr.color.r,sr.color.g,sr.color.b,1),i);
			}
		}
		if(g.GetComponent<LineRenderer>()!=null)
		{
			LineRenderer lr = g.GetComponent<LineRenderer>();
//			for(float i=0;i<1;i+=inc)
//				lr.SetColors(new Color(
			lr.enabled = true;
		}
		if(g.GetComponentInChildren<Canvas>()!=null)
		{
			g.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().enabled = true;
		}

	}
	void ShowForAllNexts(GameObject g)
	{
		Show(g);
		hideObjects.Remove(g);
	}


	//------------------------------Fading------------------------------------------------
//	IEnumerator FadeIn(SpriteRenderer r)
//	{
//		float fadespeed = 0.1f;
//		r.color = new Color(r.color.r,r.color.g,r.color.b,Mathf.Lerp(0,1,Time.deltaTime * fadespeed));
//		yield return null;
//
//	}

	//------------------------------Arrow and Text Functions-------------------------------^*

	/** Creates an arrow at the specified location and angle(degrees), 0 degrees means default sprite direction.*/
	public GameObject CreateArrow(Vector3 location, float Angle, Sprite sp =null)
	{
		GameObject arrow =  new GameObject();
		arrow.AddComponent<SpriteRenderer>();
		SpriteRenderer arrowSR = arrow.GetComponent<SpriteRenderer>();

		if(sp==null)
		{
			if(Application.loadedLevelName=="Quantum1")
				arrowSR.sprite = Resources.Load<Sprite>("QArrow");
			else if(Application.loadedLevelName=="classical")
				arrowSR.sprite = Resources.Load<Sprite>("CArrow");
		}
		else
			arrowSR.sprite = sp;
		arrow.name = "Arrow";
		float scale = 0.3160167f;
		arrow.transform.localScale = new Vector3(scale,scale,scale);
		arrow.transform.Rotate(Vector3.forward,Angle);
		arrow.transform.position = new Vector3(location.x,location.y,location.z);
//		FadeIn(arrowSR);
		for(float i=0;i<1;i+=fadeInc)
		{
//			arrowSR.material.color = Color.Lerp(new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,0),new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,1),i);
			arrowSR.color = Color.Lerp(new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,0),new Color(arrowSR.color.r,arrowSR.color.g,arrowSR.color.b,1),i);
		}
		return arrow;
	}
	/** Creates the input text at the specified location. 
	 * Default font: Gill Sans
	 * Default color: White */
	public GameObject CreateText(Vector3 location, String texter)
	{
		GameObject textBox =  new GameObject();
		textBox.name = "Text:" + texter;
		textBox.transform.position = location;
		GameObject canvas = (GameObject)Instantiate(Resources.Load("Canvas"));
		canvas.transform.parent = textBox.transform;
		canvas.transform.position = textBox.transform.position;
		Text words = canvas.GetComponentInChildren<Text>();
		words.text = texter;
		return textBox;
	}
	/** Creates an arrow depending on level with orientation: "up","down","left","right" and 
	 * offset by a shift with the gameobject depending on the gameobject sprite size.*/
	public GameObject CreateArrowG(GameObject g, String orientation = "down", Sprite sp =null)
	{
		Vector3 location;
		float extent;
		location = g.transform.position;
//		if(g.GetComponent<SpriteRenderer>()!=null)
//		{
//			if(orientation.ToLower() == "up" || orientation.ToLower() == "down")
//				extent = Mathf.Abs(g.GetComponent<SpriteRenderer>().bounds.center.y - g.GetComponent<SpriteRenderer>().bounds.extents.y);
//			else
//				extent = Mathf.Abs(g.GetComponent<SpriteRenderer>().bounds.size.x);
//		}
//		else
			extent = 0.35f;

		float angle=0;
		if(orientation.ToLower() == "up")
		{
			
			location = new Vector3(location.x,location.y-extent,location.z);
			angle = 180;
		}
		else if(orientation.ToLower() == "down")
		{
			
			location = new Vector3(location.x,location.y+extent,location.z);
			angle =0;
		}
		else if(orientation.ToLower() == "right")
		{
			
			location = new Vector3(location.x-extent,location.y,location.z);
			angle = 90;
		}
		else if(orientation.ToLower() == "left")
		{
			
			location = new Vector3(location.x+extent,location.y,location.z);
			angle =-90;
		}
		else
		{
			Debug.LogError("No matching arrow orientation");
		}
		 
		return CreateArrow(location,angle, sp);
	}

	/** Creates a text depending on level with orientation: "up","down","left","right" and 
	 * offset by a shift with the gameobject depending on the gameobject sprite size.*/
	public GameObject CreateTextG(GameObject g, String texter, String orientation = "down")
	{
		Vector3 extent, location;
		location = g.transform.position;
		if(g.GetComponent<SpriteRenderer>()!=null)
			extent = (2f/3)*g.GetComponent<SpriteRenderer>().bounds.size;
		else
			extent = new Vector3(0.3f,0.3f,0);

		if(orientation.ToLower() == "up")
			location = new Vector3(location.x,location.y-1.2f*extent.y,location.z);
		else if(orientation.ToLower() == "down")
			location = new Vector3(location.x,location.y+extent.y,location.z);
		else if(orientation.ToLower() == "right")
			location = new Vector3(location.x-extent.x,location.y,location.z);
		else if(orientation.ToLower() == "left")
			location = new Vector3(location.x+extent.y,location.y,location.z);
		else
			Debug.LogError("No matching text orientation");
		
		return CreateText(location, texter);
		
	}
	/** Creates a combined Text and arrow set with correct spacing with respect to a given gameobject and 
	 * with the specified pointing orientation. */
	public GameObject CreateTextArrow(GameObject g, String texter, String orientation = "down", Sprite sp =null)
	{
		GameObject arrow = CreateArrowG(g,orientation);
		GameObject textArrow = CreateTextG(arrow,texter,orientation);
		arrow.transform.parent = textArrow.transform;
		textArrow.tag = "TArrow";
		return textArrow;
	}
	/** Creates a combined Text and arrow set with correct spacing with respect to a given gameobject, the shift from it and 
	 * with the specified pointing orientation. */
	public GameObject CreateTextArrow(GameObject g, Vector3 shift, String texter, String orientation = "down", Sprite sp =null)
	{
		Vector3 shifter = g.transform.position+shift;
		GameObject dummyShiftedG = new GameObject();
		dummyShiftedG.tag = "dummyG";
		dummyShiftedG.transform.position = shifter;
		GameObject arrow = CreateArrowG(dummyShiftedG,orientation);
		GameObject textArrow = CreateTextG(arrow,texter,orientation);
		arrow.transform.parent = textArrow.transform;
		textArrow.tag = "TArrow";
		return textArrow;
	}
	/** Creates a combined Text and arrow set with correct spacing with respect to a given arrow location and 
	 * with the specified pointing orientation. */
	public GameObject CreateTextArrow(Vector3 location, String texter, String orientation = "down", Sprite sp =null)
	{
		GameObject g = new GameObject();
		g.transform.position = location;
		GameObject arrow = CreateArrowG(g,orientation,sp);
		GameObject textArrow = CreateTextG(arrow,texter,orientation);
		arrow.transform.parent = textArrow.transform;
		g.transform.parent = textArrow.transform;
		textArrow.tag = "TArrow";
		return textArrow;
	}
	/** Creates a combined Text and arrow set with correct spacing with respect to a given text and arrow location and 
	 * angle. */
	public GameObject CreateTextArrow(Vector3 arrowLocation, Vector3 textLocation, float Angle, String texter, Sprite sp =null)
	{
		GameObject arrow = CreateArrow(arrowLocation,Angle,sp);
		GameObject textArrow = CreateText(textLocation,texter);
		arrow.transform.parent = textArrow.transform;
		textArrow.tag = "TArrow";
		return textArrow;
	}
	//-----------------------------------Other functions-------------------------------------
	private string ResolveTextSize(string input, int lineLength){

		// Split string by char " "         
		string[] words = input.Split(" "[0]);

		// Prepare result
		string result = "";

		// Temp line string
		string line = "";

		// for each all words        
		foreach(string s in words){
			// Append current word into line
			string temp = line + " " + s;

			// If line length is bigger than lineLength
			if(temp.Length > lineLength){

				// Append current line into result
				result += line + "\n";
				// Remain word append into new line
				line = s;
			}
			// Append current word into current line
			else {
				line = temp;
			}
		}

		// Append last line into result        
		result += line;

		// Remove first " " char
		return result.Substring(1,result.Length-1);
	}
	void MakeTrail()
	{

		GameObject particle = GameObject.FindGameObjectWithTag("Particle");
		GameObject clone = new GameObject();
		clone.AddComponent<SpriteRenderer>();	
		Color c = new Color (255,255,255,0.02f);
		clone.GetComponent<SpriteRenderer>().color = c;
		clone.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("electron");

		clone.transform.position = new Vector2(particle.transform.position.x, particle.transform.position.y);
		clone.transform.localScale = particle.transform.localScale;
		clone.transform.parent = GameObject.Find ("Trail").transform;


	}
	void ButtonEnable(GameObject g)
	{
		g.GetComponent<Button>().interactable = true;
		Color c = new Color(1,1,1,1);
		ColorBlock cb = g.GetComponent<Button>().colors;
		g.GetComponent<Image>().color = c;
		cb.normalColor = c;
		g.GetComponent<Button>().colors = cb;
	}
	void ButtonDisable(GameObject g)
	{
		g.GetComponent<Button>().interactable = false;

		Color c = new Color(0,0,0,0);
		ColorBlock cb = g.GetComponent<Button>().colors;
		g.GetComponent<Image>().color = c;
		cb.normalColor = c;
		g.GetComponent<Button>().colors = cb;
	}
//	IEnumerator FadeIn(Renderer rend)
//	{
//		float f = 0.0f; 
//
//		rend.enabled = true; 
//		rend.material.color = Color.clear; 
////		scoreText.renderer.material.color = Color.clear; 
////		scoreText.renderer.enabled = true; 
//
//		while (f < 1.0f)
//		{
//			yield return null; 
//			f += Time.deltaTime; 
//			rend.material.color = new Color(1,1,1, Mathfx.Hermite (0, 1, f) ); 
//			scoreText.renderer.material.color = new Color(1,1,1, Mathfx.Hermite (0, 1, f) ); 
//		}
//
//		rend.material.color = Color.white; 
//	}
}
