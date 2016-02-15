using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tutorialManager : MonoBehaviour {

	// Use this for initialization
	public static int i=0,c=0;
	FadeScript fadeScript;
	public static bool boltGone = false;
	void Start () {
		fadeScript = GetComponent<FadeScript>();
		if(gameObject.tag == "RedLine")
			GetComponent<LineRenderer>().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		sequence();

		   
	
	}
	public void incrementi()
	{
		if(boltGone && i == 6)
		{
			i += 2;
			Debug.Log(i);
		}
		else
			i++;
	}
	public void decrementi()
	{
		if(boltGone && i == 8)
		{
			i -= 2;
			Debug.Log(i);
		}
		else
			i--;

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
		}

		if(i==2)
		{
			if(c==0)
			{
				ballFadeScript.ball = true;
				c=1;
//				if(ballFadeScript.ball)
//					Debug.Log (ballFadeScript.ball);
			}

		}

		if(i==4)
		{
			if(tag == "PE" || tag == "Overlay")
			{

				fadeScript.fade = true;

			}
				
		}
		if(i==5)
		{
			if(gameObject.tag == "TE")
				fadeScript.fade = true;
		}
		if(i==6)
		{
			if(gameObject.tag == "RedLine")
				GetComponent<LineRenderer>().enabled = true;
		}
		if(i==7 && !boltGone)
		{

			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = false;
				GetComponent<Animator>().SetTrigger("buttonFadeOut");
				Color c = new Color(0,0,0,0);
			
				gameObject.GetComponent<Image>().color = c;

			}
			//Debug.Log (i);
			boltFade.bolt = true;
		}

		if(i==8)
		{
			boltGone = true;
			if(slidingDoorScript2.doorOpen2==true)
			{
				if(gameObject.tag == "Button")	
				{
					GetComponent<Animator>().SetTrigger("buttonFade");
					gameObject.GetComponent<Button>().interactable = true;
					
					Color c = new Color(255,255,255,1);
					
					gameObject.GetComponent<Image>().color = c;
					
				}
			}


		}

		if(i==9)
		{


			if(gameObject.tag == "Button")	
			{
				gameObject.GetComponent<Button>().interactable = false;
				GetComponent<Animator>().SetTrigger("buttonFadeOut");
				Color c = new Color(0,0,0,0);

				gameObject.GetComponent<Image>().color = c;
				
			}
			GameObject.FindGameObjectWithTag("InstructionText").GetComponent<MeshRenderer>().enabled = false;


			GameObject ib = GameObject.Find("instruction bubble");
			ib.transform.position = new Vector2(ib.transform.position.x + 10.24f,ib.transform.position.y);
			ib.GetComponentInChildren<Animator>().ResetTrigger("instructionOpen");
			ib.GetComponentInChildren<Animator>().SetTrigger("instructionClose");
			ib.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().SetTrigger("instructionClose");
			ib.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().ResetTrigger("instructionOpen");

			
		}
		
		
	}
}
