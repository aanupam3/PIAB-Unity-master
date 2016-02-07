using UnityEngine;
using System.Collections;

public class qParticleScript : MonoBehaviour {

	// Use this for initialization
	float[] prob,x,cumprob;
	float nextTime, persistTime;
	public static float delay = 0.5f, persist = 0.3f,y;
	public static bool notHold = true, hold = true;

	void Start () 
	{
		y = gameObject.transform.position.y;
		nextTime = Time.time + delay;
		persistTime = Time.time + persist;
		delay = 0.5f;
		persist = 0.3f;
		notHold = true;
		hold = true;
//		Color c = new Color(255,255,255,0);
//		GetComponent<SpriteRenderer>().color = c;
//		Debug.Log ("Electron alpha is: " + GetComponent<SpriteRenderer>().color.a);
	}


	// Update is called once per frame
	/**
	 * The cumulative probability of each point(or index) which has been calculated from the PsiCalc script is used
	 * Random value is generated between 0 and 1
	 * This random value is compared to each point's cumulative probability 
	 * Once we know which cumulative probability is closest to this random value, we find the index corresponding to it
	 * This index is used in the array of x positions calculated similarly to the PsiCalc script to give the x value for the electron
	 * */
	void FixedUpdate ()  
	{

		prob = PsiCalc.probM;
		x=xF();
		if(Time.fixedTime>nextTime) //wait for delay
		{
			float rand = Random.value;
			for(int i=1; i<prob.Length; i++)
			{
				if(rand <= PsiCalc.cumprob[i] && rand>= PsiCalc.cumprob[i-1])
				{
					if(notHold)
					{
						gameObject.transform.position = new Vector2(x[i],y);
						notHold = false;
						hold = true;
						//Debug.Log(y);//Display Electron
						break;
					}
				}
			}
	


		}
		if(Time.fixedTime>nextTime + persist)
		{
			gameObject.transform.position = new Vector2(100,100);
			nextTime = Time.time + delay;
			notHold = true;
			hold = false;
			//persistTime = Time.time + persist;
		}


				
	}


	public float[] xF()
	{
		float[] x = new float[PsiCalc.num_points];
		x[0] = PsiCalc.xmin;
		for (int i=1; i<PsiCalc.num_points; i++)
		{
			x[i] = x[i-1]+PsiCalc.dx;
		}
		return x;
	}
}
