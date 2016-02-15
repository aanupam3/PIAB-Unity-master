using UnityEngine;
using System.Collections;

public class arrowManagerQ : MonoBehaviour {

	// Use this for initialization
	GameObject[] arrows;
	int i;
	float initBoltPosition;
	GameObject lightSource;
	void Start () {
		//initBoltPosition = GameObject.Find ("thunderboltTutorial").transform.position.x;
		lightSource = GameObject.FindGameObjectWithTag("LightSource");

		arrows = new GameObject[0];
		i = tutorialManager.i;
		foreach(Transform t in transform)
		{
			//Debug.Log (t);
			arrows = ArrayTools.PushLast(arrows,t.gameObject);
//			Debug.Log(t.name);
		}
//		Debug.Log(transform.childCount);
//		for(int i=0;i<transform.childCount;i++)
//		{
//			
//		}
		Debug.Log("Arrow length: " + arrows.Length);
	
	}
	
	// Update is called once per frame
	void Update () {
		i = tutorialManagerQ.i;
		if(i==0)
		{
			fadeOut(arrows[0]);
		}

		if(i==1)
		{
			fadeIn(arrows[0]);
		}

		if(i==2)
		{
			fadeOut(arrows[0]);
			fadeOut(arrows[16]);
			//fadeIn(arrows[1]);
		}

		if(i==3)
		{
			fadeIn(arrows[16]);
		}
		if(i==4)
		{
			fadeOut(arrows[16]);
			fadeOut(arrows[1]);
		}
		if(i==6)
		{

			fadeIn(arrows[1]);
			fadeOut(arrows[2]);
		}
		if(i==7)
		{
			fadeIn(arrows[2]);
			fadeOut(arrows[3]);
		}
		if(i==8)
		{
			fadeOut(arrows[1]);
			fadeOut(arrows[2]);
			fadeIn(arrows[3]);
			fadeOut(arrows[4]);
			fadeOut(arrows[5]);
			fadeOut(arrows[6]);
			fadeOut(arrows[7]);
		}
		if(i==9)
		{
			fadeOut(arrows[3]);
			fadeInAlpha(arrows[4]);
			fadeInAlpha(arrows[5]);
			fadeInAlpha(arrows[6]);
			fadeInAlpha(arrows[7]);
			fadeOut(arrows[8]);
		}
		if(i==10)
		{
			fadeIn(arrows[8]);
			fadeOut(arrows[9]);
			fadeOut(arrows[11]);

		}
		if(i==11)
		{

			fadeIn(arrows[11]);
			fadeIn(arrows[9]);
			//fadeIn(arrows[10]);
			fadeOut(arrows[8]);
			fadeOut(arrows[15]);

			fadeOut(arrows[17]);
			fadeOut(arrows[18]);

		}
		if(i==12)
		{
			fadeIn(arrows[17]);
			fadeIn(arrows[18]);
		}
		if(i==13)
		{
			fadeOut(arrows[9]);
			//fadeOut(arrows[10]);
			fadeOut(arrows[11]);
			fadeIn(arrows[15]);
			fadeOut(arrows[13]);
			fadeOut(arrows[14]);

		}
		if(i==14)
		{
			fadeIn(arrows[14]);
			fadeIn (arrows[13]);
			fadeOut(arrows[15]);
			fadeOut(arrows[12]);
			fadeOut(arrows[17]);
			fadeOut(arrows[18]);
		}
		if(i==15)
		{

			fadeOut(arrows[14]);
			fadeIn (arrows[12]);
		}
		if(i==16)
		{
			fadeOut(arrows[13]);
			fadeOut(arrows[12]);
			fadeOut (arrows[19]);
		}
		if(i==17 && lightSource.GetComponent<lightSourceScript>().weightsCollected == lightSource.GetComponent<lightSourceScript>().totalWeights)
		{

			fadeIn(arrows[19]);
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

		textAnim.ResetTrigger("textFadeAlpha");


	}
	void fadeInAlpha(GameObject arrow)
	{
		Animator anim, textAnim;
		anim = arrow.GetComponent<Animator>();
		textAnim = arrow.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
		
		//anim.ResetTrigger("fadeOut");
		textAnim.ResetTrigger("textFadeOut");
		//anim.SetTrigger("fade");
		textAnim.SetTrigger("textFadeAlpha");
	}
}
