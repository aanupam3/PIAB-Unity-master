using UnityEngine;
using System.Collections;

public class PotentialProfile : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRendererV;
	GameObject[] Charges;
	bool changeAble = true, initialRecalc = true;
	float[] initChargeScale;
	public static bool dragging = true;
	void Start () {
		lineRendererV = GetComponent<LineRenderer>();

		Charges = GameObject.FindGameObjectsWithTag("Charge");
		initChargeScale = new float[Charges.Length];
		for(int i=0;i<initChargeScale.Length;i++)
			initChargeScale[i] = Charges[i].gameObject.transform.lossyScale.magnitude;
		float[] pe_profile = PsiCalc.pe_profile;
		if(Application.loadedLevelName == "Quantum1a")
		{
			for (int j=0; j<pe_profile.Length;j++)
			{
				
				if(j<pe_profile.Length/2)
					pe_profile[j] = 0;
				else if(j>pe_profile.Length/2 && j<2*pe_profile.Length/3 )
					pe_profile[j] = 2.5f;
				else
					pe_profile[j] = 1.1f;
				
			}
			PsiCalc.calcSignal = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(changeAble)
		{
			if(Application.loadedLevelName == "Quantum1" || Application.loadedLevelName == "Quantum1a")
			{
				ProfilePlot();
				changeAble = false;
			}

			else 
			{
				if(dragging)
				{
					changePlot();
					ProfilePlot();
					dragging = false;
				}
				if(initialRecalc)
				{
					PsiCalc.calcSignal = true;
					initialRecalc = false;
				}

			}
		}
		if(Input.GetKey(KeyCode.Return))
		{
			PsiCalc.calcSignal = true;
		}

	}
	public void ProfilePlot ()
	{
		//ArrayTools.Update(PsiCalc.pe_profile,a => a+PsiCalc.yOffset);
		float x = PsiCalc.xmin;
		int n =1;
		int num_points = n*PsiCalc.num_points-n+1;
		float[] interPolate = new float[num_points];
		lineRendererV.SetVertexCount(num_points-1);
		for(int j=0;j<num_points;)
		{
			if(j%n==0)
			{
				interPolate[j]=PsiCalc.pe_profile[j/n];
				j++;

			}
			else if(j<=num_points-n)
			{
				for(int k=1;k<n;k++)
				{
					interPolate[j]=(k/n)*PsiCalc.pe_profile[(j/n)+1]+PsiCalc.pe_profile[(j/n)];
					j++;

				}
			}


		}
		for(int j=0;j<num_points-1;j++)
		{
			lineRendererV.SetPosition(j, new Vector3(x,interPolate[j]/2 + PsiCalc.yOffset,0));
			x = x + PsiCalc.dx/n;
			
		}
		//gameObject.GetComponentsInChildren<LineRenderer>()[1].SetPosition(0, new Vector3(-4,5,0));
		gameObject.GetComponentsInChildren<LineRenderer>()[1].SetPosition(0, new Vector3(PsiCalc.xmin,5,0));
		gameObject.GetComponentsInChildren<LineRenderer>()[1].SetPosition(1, new Vector3(PsiCalc.xmin,PsiCalc.pe_profile[0]/2 + PsiCalc.yOffset,0));
		gameObject.GetComponentsInChildren<LineRenderer>()[2].SetPosition(0, new Vector3(x-PsiCalc.dx,5,0));
		gameObject.GetComponentsInChildren<LineRenderer>()[2].SetPosition(1, new Vector3(x-PsiCalc.dx,PsiCalc.pe_profile[PsiCalc.pe_profile.Length-1]/2 + PsiCalc.yOffset,0));
		//Debug.Log(gameObject.GetComponentsInChildren<LineRenderer>()[1].name);

	}

	public void changePlot()
	{

	
		int[] Charge_xIndex = new int[Charges.Length];
		float[] Charges_x = new float[Charges.Length];
		float[] chargeValue = new float[Charges.Length];
		for(int i=0;i<Charges.Length;i++)
		{

			float Charge_x = Charges[i].transform.position.x-PsiCalc.xmin;
			Charges_x[i] = 2*Charges[i].transform.position.x/(PsiCalc.xmax-PsiCalc.xmin);
			Charge_xIndex[i] = Mathf.RoundToInt((Charge_x/(PsiCalc.xmax-PsiCalc.xmin))*PsiCalc.num_points);
			if(Charge_xIndex[i]>=PsiCalc.num_points)
				Charge_xIndex[i] = PsiCalc.num_points-1;
			if(Charge_xIndex[i]<0)
				Charge_xIndex[i]=0;
			//Debug.Log(Charges[i].gameObject.GetComponent<SpriteRenderer>().bounds.size.x);
			if(Charges[i].gameObject.GetComponent<SpriteRenderer>().sprite.name=="negativeCharge")
				chargeValue[i] = -0.5f*Charges[i].gameObject.transform.lossyScale.magnitude/initChargeScale[i];
			else 
				chargeValue[i]= 0.5f*Charges[i].gameObject.transform.lossyScale.magnitude/initChargeScale[i];

		}


		float[] pe_profile = PsiCalc.pe_profile;

		for (int i=0; i<PsiCalc.pe_profile.Length;i++)
		{


			float sumCharge = 0;
			for(int j=0; j<Charge_xIndex.Length; j++)
			{

				sumCharge +=  - chargeValue[j]/Mathf.Sqrt(Mathf.Pow(((Charges_x[j])-PsiCalc.xss[i]),2)+0.1078f);
				//pe_profile[i] +=  - chargeValue[j]/Mathf.Sqrt(Mathf.Pow(((Charges_x[j])-PsiCalc.xss[i]),2)+0.1078f);

			}
			pe_profile[i] = sumCharge;

		}


	}

}
