using UnityEngine;
//using UnityEditor;
using System.Collections;


public class PsiCalc : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRenderer;
	int i=0;
	bool moveDown = true;
	public static int E;
	public static float[] pe_profile, energy_set, psi_valuesInit, probM, cumprob,xss;
	public static bool calcSignal;
	public static float xmin, xmax, dx;
	public static int num_points, num_elevel, vertical_steps;
	public static float yOffset = 1.1f, yOffset2 = -1.628f;
	float[][] psiAnim;
	void Awake()
	{
		i=0;
		num_elevel = 4;
		E=0;
		calcSignal = false;
		lineRenderer = GetComponent<LineRenderer>();
		num_points = 105;
		int[] numpointsArray = new int[1]{num_points};

		float[][] pe_profile2 = numeric.rep(numpointsArray, 0);
		pe_profile = pe_profile2[0];

		psiCalcDisplay();
//		GameObject.FindGameObjectWithTag("Spawn").transform.position = new Vector2(-4.51f,-0.58f);
		if(Application.loadedLevelName == "Quantum1")
		{
			Color c = new Color(1,1,1,0);
			GameObject.FindGameObjectWithTag("Particle").GetComponent<SpriteRenderer>().color = c;
			//Debug.Log ("Ghusa");
		}


	}
	void Start()
	{
		E=0;
		i=0;
		//GameObject.FindGameObjectWithTag("Spawn").transform.position = new Vector2(-4.51f,-0.58f);
		//Debug.Log (GameObject.FindGameObjectWithTag("Spawn").transform.position);
		if(Application.loadedLevelName == "Quantum1")
			yOffset = 0.5f;
		else if(Application.loadedLevelName == "Quantum1a")
			yOffset = 0.0f;
		else
			yOffset = 1.1f;
		if(Application.loadedLevelName == "Quantum1")
		{
			Color c = new Color(255,255,255,0);
			GameObject.FindGameObjectWithTag("Particle").GetComponent<SpriteRenderer>().color = c;
			//Debug.Log ("Ghusa");
		}
	}
	void psiCalcDisplay () 
	{

		float[][] psi_set;
		float[]  charges, charges_x, charges_y;
		object[] solution;

//		vertical_steps=100;
		 //number of eigen energies
		xmin = -3.86f;
		xmax = 4.15f;
		xss = numeric.linspace(-1.0f, 1.0f, num_points);


		charges = new float[2]{10, -15};
		charges_x = new float[2]{-0.5f, 0.5f};
		charges_y = new float[2]{0.1f, 0.1f};
		dx = (xmax-xmin)/(num_points);
		
		solution = (object[])Wavefunction(xmin, xmax, num_points, num_elevel, pe_profile);
		energy_set = (float[])solution[0];
		ArrayTools.Update(energy_set,x => x+yOffset2);
		psi_set = (float[][])solution[1];
		lineRenderer.SetVertexCount(num_points);
		 
		psi_valuesInit = psi_set[E]; 
		float a = (E+1.0f)/num_elevel;
//		Debug.Log(a);
		vertical_steps = Mathf.FloorToInt(50.0f/a);
		psiAnim = psiMotionArray(psi_valuesInit,vertical_steps);

		probM = prob(psi_valuesInit);
		cumprob = new float[probM.Length];
		cumprob[0]=probM[0];
		float sumprob =0;
		for(int i=0;i<probM.Length;i++)
		{
			sumprob = sumprob + probM[i];
		}
		
		for(int i=1;i<probM.Length;i++)
		{
			cumprob[i]= cumprob[i-1]+probM[i];
			
		}
		for(int i=0;i<cumprob.Length;i++)
		{
			cumprob[i] = cumprob[i]/sumprob;
		}
		EnergyLevels.ePlotsignal = true;
		GameObject.Find("Wire").GetComponent<WireColor>().probSignal = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(calcSignal)
		{
			psiCalcDisplay();
			calcSignal = false;
		}

		if (i<=0)
		{
			moveDown = true;
		}
		if (i>=vertical_steps-1)
		{
			moveDown = false;
		}
		if(i<vertical_steps && moveDown)
		{
			
			i++;
		}
		if(i>0 && !moveDown)
		{
			i--;
		}
		float x = xmin;
		lineRenderer.SetPosition(0, new Vector3(xmin-dx,yOffset2,-0.1f));

		for(int j=1;j<num_points-1;j++)
		{
			//Debug.Log (x);

			lineRenderer.SetPosition(j, new Vector3(x,psiAnim[i][j-1]+yOffset2,-0.1f));
			x = x + dx;

		}
		lineRenderer.SetPosition(num_points-1, new Vector3(xmax-2*dx,yOffset2,-0.1f));
//		lineRenderer.SetPosition(num_points, new Vector3(xmax,yOffset2,-0.1f));
		
		

	
	}

	float[][] psiMotionArray(float[] psi_valuesInit, int steps)
	{
		float[][] ret = new float[steps][];

		for(int i=0; i<steps;i++)
		{
			ret[i] = new float[psi_valuesInit.Length];
			for(int j=0;j<psi_valuesInit.Length;j++)
			{
				float dy = 2*psi_valuesInit[j]/steps;
				if(i>0)
					ret[i][j]= ret[i-1][j]-dy;
				else
					ret[i][j] = psi_valuesInit[j];

			}
		}


		return ret;
	}
	object Wavefunction(float xmin,float xmax,int num_points,int num_elevel,float[] PE)
	{

		float HBAR = 6.62606957E-34f;
		float NM2M = 1E-9f;
		float EV2J = 1.6E-19f;
		float mass = 9.10938291E-31f;
		float C = (-HBAR*HBAR/(2*mass))/(NM2M*NM2M*EV2J);

		float[] xx = numeric.linspace(xmin,xmax,num_points-2);
		float dx = (xmax-xmin)/(num_points);
		int factor = (int)Mathf.Round(C/(dx*dx));
		int[] a = new int[1]{num_points-2};

		float[][] melement = numeric.rep(a,-2*factor);
		float[][] K = numeric.diag(melement[0]);

		for (int i=0; i<num_points-3; i++) 
		{
			K[i][i+1] = factor;
			K[i+1][i] = factor;
		} //kinetic energy matrix
		//float[][] P = new float[][];

		float[] P1 = ArrayTools.SubArray(PE,1,num_points-1);

		int shift =0;
		float min_pe = Mathf.Min(P1);
		bool shift_flag = false;
		//The min PE val is a lowerbound on the eigenvalues(Gershgorin).
		//If too close to negative values shift eigenvalues to guarentee positivity.
		if(min_pe < numeric.epsilon)
		{
			shift = (int)Mathf.Round(Mathf.Abs(min_pe) + 1);
			shift_flag = true;
		}
		float[][] P = numeric.diag(P1);

		float[][] H = new float[K.Length][]; 
		for(int i=0;i<K.Length;i++)
		{
			H[i] = new float[K[i].Length];
			for(int j=0;j<K[i].Length;j++)
				H[i][j] = K[i][j]+P[i][j];
		}
	

		if(shift_flag)
		{
			float[][] element = numeric.rep(a, shift);
			float[][] Hadd = numeric.diag(element[0]);
			for(int i=0;i<H.Length;i++)
			{
				for(int j=0;j<H[0].Length;j++)
					H[i][j] = Hadd[i][j]+H[i][j];
			}
		}
		object[] eigen = (object[])numeric.svd(H);

		float[][] U = numeric.transpose((float[][])eigen[0]);
		float[] S = (float[])eigen[1];
		if(shift_flag){
			for(int i=0;i<S.Length;i++)
				S[i] = S[i] - shift;
		}
		
		float[][] psi_array = new float[num_points-2][];

		
		for(int i=0; i<num_points-2; i++)
		{
			float[] psi = U[i];
			ArrayTools.Push(psi,0);
			ArrayTools.PushLast(psi,0);

			float area = trapz(dx, prob (psi));
			for(int j=0;j<psi.Length;j++)
			{
				psi[j] = psi[j]/Mathf.Sqrt(area);
			}

			psi_array[i] = psi;
		}
		
		//Collect the desired number of energy levels.
		float[][] wave_eqs = new float[num_elevel][];
		float[] eng_lvls = new float[num_elevel];
		for(int i=0; i<num_elevel; i++)
		{
			wave_eqs[i] = psi_array[num_points - 3 - i];
			eng_lvls[i] = S[num_points - 3 - i];
		}
		object[] obj = new object[2];
		obj[0] = eng_lvls;
		obj[1] = wave_eqs;
		return obj;

	}
	float[] prob(float[] psi) 
	{
		float[] prob = new float[psi.Length];
		for (int i=0; i<psi.Length; i++)
		{
			prob[i] = psi[i]*psi[i];
		}
		return prob;
	}

//Applys the trapezoidal rule on vector y with uniform spacing dx.
	float trapz(float dx,float[] y) 
	{
		int i, n;
		float sum;
		n = y.Length - 1;
		sum = (y[0] + y[n])/2;
		for(i=1; i<n; i++)
		{
			sum += y[i];
		}
		return sum * dx;
	}

}
