using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tutorialManagerQ : MonoBehaviour {

	// Use this for initialization
	public static int i=0,c=0;
	static bool meas1 = false, meas2 = false;
	bool ccount = true, appOnce = true;
	FadeScript fadeScript;
	int currentChildren = 0;
	GameObject player;
	public static bool wCol = false;
	void Start () {
		//if(i!=13 || i!=15)

		//i=0;
		player = GameObject.FindGameObjectWithTag("Player");
		c=0;
		ccount = true;
		appOnce = true;
		currentChildren = 0;
		fadeScript = GetComponent<FadeScript>();
		//if(gameObject.tag == "RedLine")
//		meas1 = false;
//		meas2 = true;
		if(GetComponent<LineRenderer>()!=null)
			GetComponent<LineRenderer>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		sequence();
		//Debug.Log (i);
		   
	
	}
	public void incrementi()
	{
		if(wCol && i == 12)
		{
			i += 2;
			Debug.Log(i);
		}
		else
			i++;
	}
	public void decrementi()
	{
		if(wCol && i == 14)
		{
			i -= 2;
			Debug.Log(i);
		}
		else
			i--;
		
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
	public void sequence ()
	{
		if(i==0)
		{
			if(gameObject.name == "BackButton")	
			{
				gameObject.GetComponent<Button>().interactable = false;
				GetComponent<Animator>().SetTrigger("buttonFadeOut");
				Color c = new Color(0,0,0,0);
				
				gameObject.GetComponent<Image>().color = c;
				
			}
			if(gameObject.name == "Button")	
			{
				GetComponent<Animator>().SetTrigger("buttonFade");
				gameObject.GetComponent<Button>().interactable = true;
				
				Color c = new Color(255,255,255,1);
				
				gameObject.GetComponent<Image>().color = c;
				
			}
		}

		if(i==1)
		{
			if(gameObject.name == "BackButton")	
			{
				GetComponent<Animator>().SetTrigger("buttonFade");
				gameObject.GetComponent<Button>().interactable = true;
				
				Color c = new Color(255,255,255,1);
				
				gameObject.GetComponent<Image>().color = c;
				
			}
			if(tag == "PsiCalc")
				GetComponent<LineRenderer>().enabled = true;
			if(gameObject.name == "MeasurementLine")
			{
				GetComponent<LineRenderer>().enabled = false;
				Animator textAnim = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
				textAnim.ResetTrigger("textFadeIn");
				textAnim.SetTrigger("textFadeOut");
			}
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

						MakeTrail();

					}


				}

			}



		}
		if(i==3)
		{
			qParticleScript.delay=0.5f;
			qParticleScript.persist=0.3f;
			if(gameObject.name == "MeasurementLine")// && meas1 == false)
			{
				GameObject particle = GameObject.FindGameObjectWithTag("Particle");
				Animator textAnim = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
				textAnim.ResetTrigger("textFadeIn");
				textAnim.SetTrigger("textFadeOut");
				GetComponent<LineRenderer>().enabled = false;
			}
			if(GameObject.FindGameObjectWithTag("Particle").transform.position.x<10 && qParticleScript.hold && gameObject.name == "MeasurementLine")
				MakeTrail();
		}
		if(i==4)
		{

			if(ccount)
				currentChildren = GameObject.Find ("Trail").transform.childCount;
			ccount = false;

			if(GameObject.FindGameObjectWithTag("Particle").transform.position.x<10 && qParticleScript.hold && gameObject.name == "MeasurementLine")
				MakeTrail();
			qParticleScript.delay=0.05f;
			qParticleScript.persist=0.1f;
			
			if(GameObject.Find ("Trail").transform.childCount>currentChildren + 0) //Trail COUNT
			{
				if(gameObject.tag == "Button")	
				{
					gameObject.GetComponent<Button>().interactable = true;
					
					Color c = new Color(255,255,255,1);
					
					gameObject.GetComponent<Image>().color = c;
					
				}

			}
			else	
			{

			
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
		if(i==5)
		{
			qParticleScript.delay=1f;
			qParticleScript.persist=0.5f;
			if(GameObject.FindGameObjectWithTag("Particle").transform.position.x<10 && qParticleScript.hold && gameObject.name == "MeasurementLine")
				MakeTrail();
			
			if(gameObject.name == "WaveProbability")
			{
				GetComponent<Animator>().ResetTrigger("fadeOut");
				GetComponent<Animator>().SetTrigger("fade");
			}

		}
		//if(i==6)

	
		if(i==8)
		{
			//GameObject.Find("Trail").SetActive(false);
			Destroy (GameObject.Find("Trail"));
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
		if(i==9)
		{
			//
		}
		if(i>=9)
		{
			if(tag == "EnergyLevel")
			{
				GetComponent<LineRenderer>().enabled = true;
			}

		}
		if(i==10)
		{
			if(gameObject.tag == "Weight")
			{
				GetComponent<Animator>().ResetTrigger("fade");
				GetComponent<Animator>().SetTrigger("fadeOut");
			}
		}
		if(i==11)
		{
			if(gameObject.tag == "Weight")
			{
				GetComponent<Animator>().ResetTrigger("fadeOut");
				GetComponent<Animator>().SetTrigger("fade");
			}
		}
		if(i==12)
		{
			player.GetComponent<Animator>().ResetTrigger("Unlock");
			player.GetComponent<Animator>().SetTrigger("Lock");
			if(gameObject.tag == "LightSource")
			{
				GetComponent<Animator>().SetTrigger("fade");
				GetComponent<Animator>().ResetTrigger("fadeOut");
			}
			if(gameObject.tag == "Button")
			{
				//GetComponent<Animator>().SetTrigger("buttonFadeOut");
				//GetComponent<Animator>().ResetTrigger("buttonFade");
			}
			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = true;
				
				Color c = new Color(255,255,255,1);
				
				gameObject.GetComponent<Image>().color = c;
				
			}
		}
		if(i==13 && !wCol)
		{
			if(gameObject.tag == "LightSource")
				GetComponent<Animator>().SetTrigger("fade");
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
		if(i==14)
		{
			player.GetComponent<Animator>().ResetTrigger("Unlock");
			player.GetComponent<Animator>().SetTrigger("Lock");
			//player.GetComponent<Rigidbody2D>().simulated = false;
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
			wCol = true;
		}
		 
		if(i==17)
		{
			player.GetComponent<Animator>().ResetTrigger("Lock");
			player.GetComponent<Animator>().SetTrigger("Unlock");
			//player.GetComponent<Rigidbody2D>().simulated = true;
			if(gameObject.tag == "Button")
				GetComponent<Animator>().SetTrigger("buttonFadeOut");

			GameObject ib = GameObject.Find("instruction bubble");
			//ib.transform.position = new Vector2(ib.transform.position.x + 10.24f,ib.transform.position.y);
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
