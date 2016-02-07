using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tutorialManagerQ2 : MonoBehaviour {

	// Use this for initialization
	public static int i=0,c=0;
	static bool meas1 = false, meas2 = false;
	bool ccount = true, appOnce = true;
	FadeScript fadeScript;
	int currentChildren = 0;


	void Start () {

		fadeScript = GetComponent<FadeScript>();

		if(GetComponent<LineRenderer>()!=null)
			GetComponent<LineRenderer>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		sequence();

		   
	
	}
	public void incrementi()
	{
		i++;
	}

	public void sequence ()
	{

		if(i==1)
		{
			if(tag == "PsiCalc")
				GetComponent<LineRenderer>().enabled = true;
		}
//		if(i>=2 && i<7)
//			MakeTrail();

		if(i==2)
		{
			if(tag == "Particle")
				GetComponent<Animator>().SetTrigger("fade");
			if(GameObject.FindGameObjectWithTag("Particle").transform.position.x<10)
			{

				if(gameObject.name == "MeasurementLine")
				{
					GameObject particle = GameObject.FindGameObjectWithTag("Particle");
					Animator textAnim = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
					if(qParticleScript.hold)
					{

						GetComponent<LineRenderer>().enabled = true;

						GetComponent<LineRenderer>().SetPosition(0,new Vector3(particle.transform.position.x, particle.transform.position.y,0));
						GetComponent<LineRenderer>().SetPosition(1,new Vector3(particle.transform.position.x, 1f,0));



						gameObject.transform.GetChild(0).GetChild(0).transform.position = new Vector3(particle.transform.position.x, 1f,0);
						textAnim.SetTrigger("textFadeIn");



					}


				}

			}



		}
		if(i==3)
		{


			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = true;
				
				Color c = new Color(255,255,255,1);
				
				gameObject.GetComponent<Image>().color = c;
				
			}

		}
		if(i==4)
		{
			
			if(gameObject.name == "WaveProbability")
			{
				GetComponent<Animator>().ResetTrigger("fadeOut");
				GetComponent<Animator>().SetTrigger("fade");
			}

		}

	
		if(i==7)
		{


			if(tag == "PotentialProfile")
				GetComponent<LineRenderer>().enabled = true;
			if(tag == "Overlay")
				GetComponent<Animator>().SetTrigger("fade");
			if(gameObject.name == "WaveProbability")
			{
				GetComponent<Animator>().ResetTrigger("fade");
				GetComponent<Animator>().SetTrigger("fadeOut");
			}
		}


		if(i>=8)
		{
			if(tag == "EnergyLevel")
			{
				GetComponent<LineRenderer>().enabled = true;
			}
		}

		if(i==12)
		{
			if(gameObject.tag == "Button")
				GetComponent<Animator>().SetTrigger("buttonFadeOut");
			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = false;
				
				Color c = new Color(0,0,0,0);
				ColorBlock cb = gameObject.GetComponent<Button>().colors;
				
				gameObject.GetComponent<Image>().color = c;
				cb.normalColor = c;
				gameObject.GetComponent<Button>().colors = cb;
				
			}
		}
		if(i==13)
		{
			if(gameObject.tag == "Button")
			{
				GetComponent<Animator>().ResetTrigger("buttonFadeOut");
				GetComponent<Animator>().SetTrigger("buttonFadeIn");
			}
			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = true;
				
				Color c = new Color(255,255,255,1);
				
				gameObject.GetComponent<Image>().color = c;

			}
		}
		//Debug.Log (i);
		if(i==16)
		{

			if(gameObject.tag == "Button")
				GetComponent<Animator>().SetTrigger("buttonFadeOut");

			GameObject ib = GameObject.Find("instruction bubble");

			ib.GetComponentInChildren<Animator>().ResetTrigger("instructionOpen");
			ib.GetComponentInChildren<Animator>().SetTrigger("instructionClose");
			ib.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().SetTrigger("instructionClose");
			ib.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().ResetTrigger("instructionOpen");
			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = false;
				
				Color c = new Color(0,0,0,0);
				ColorBlock cb = gameObject.GetComponent<Button>().colors;
				
				gameObject.GetComponent<Image>().color = c;
				cb.normalColor = c;
				gameObject.GetComponent<Button>().colors = cb;
				
			}
		}

	}
}
