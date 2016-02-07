using UnityEngine;
using System.Collections;

public class arrowManager : MonoBehaviour {

	// Use this for initialization
	GameObject[] arrows;
	int i;
	float initBoltPosition;
	void Start () {
		initBoltPosition = GameObject.Find ("thunderboltTutorial").transform.position.x;
		arrows = new GameObject[0];
		i = tutorialManager.i;
		foreach(Transform t in transform)
		{
			//Debug.Log (t);
			arrows = ArrayTools.PushLast(arrows,t.gameObject);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		i = tutorialManager.i;

		if(i==0)
		{
			fadeIn(arrows[0]);
		}

		if(i==1)
		{
			fadeOut(arrows[0]);
		}
		if(i==4)
		{
			fadeIn(arrows[1]);
		}
		if(i==5)
		{

			fadeIn(arrows[2]);
		}	
		if(i==6)
		{
			fadeIn(arrows[8]);
			fadeOut(arrows[4]);
		}
		if(i==7)
		{
			
			fadeOut(arrows[1]);
			fadeOut(arrows[2]);
			fadeOut(arrows[8]);
			fadeIn(arrows[3]);
			//fadeOut(arrows[4]);
			if(GameObject.Find ("thunderboltTutorial").transform.position.x != initBoltPosition)
			{
				fadeOut(arrows[3]);
			}
		}
		if(i==8)
		{
		
			fadeIn(arrows[4]);
			fadeOut(arrows[1]);
			fadeOut(arrows[2]);
			fadeOut(arrows[8]);
			//fadeIn(arrows[5]);
			if(slidingDoorScript2.doorOpen2)
			{
//				fadeOut(arrows[4]);
//				fadeOut(arrows[5]);
			}

		}
		if(i==9)
		{
			fadeOut(arrows[4]);
			//fadeOut(arrows[5]);
			//fadeIn(arrows[6]);

			
		}
		if(slidingDoorScript.doorOpen1)
		{
			fadeIn(arrows[7]);
		}
		
	}

	void fadeIn(GameObject arrow)
	{
		Animator anim, textAnim;
		anim = arrow.GetComponent<Animator>();
		textAnim = arrow.transform.GetChild(0).GetChild(0).GetComponent<Animator>();

		anim.ResetTrigger("fadeOut");
		textAnim.ResetTrigger("textFadeOut");
		anim.SetTrigger("fade");
		textAnim.SetTrigger("textFadeIn");
	}
	void fadeOut(GameObject arrow)
	{
		Animator anim, textAnim;
		anim = arrow.GetComponent<Animator>();
		textAnim = arrow.transform.GetChild(0).GetChild(0).GetComponent<Animator>();

		anim.ResetTrigger("fade");
		textAnim.ResetTrigger("textFadeIn");

		anim.SetTrigger("fadeOut");
		textAnim.SetTrigger("textFadeOut");


	}
}
