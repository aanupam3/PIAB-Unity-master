using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyLevels : MonoBehaviour {

	// Use this for initialization
	GameObject[] e_levels;
	public static bool ePlotsignal = false;
	LineRenderer lineRendererE;
	int prevE=-1;
	void Start () {
		e_levels = new GameObject[PsiCalc.num_elevel];

		energyPlot();

	}

	// Update is called once per frame
	void FixedUpdate () 
	{


		if(ePlotsignal)
		{
			energyPlot();
			ePlotsignal = false;
		}
		prevE=PsiCalc.E;

	
	}
	public void energyPlot()
	{

		Material m = (Material)Resources.Load("Line");
//		Material m = (Material)Resources.Load("Line");
		for(int i=0;i<PsiCalc.num_elevel;i++)
		{
			if(e_levels[i]!=null)
			{
				Destroy(e_levels[i]);
			}
			e_levels[i] = new GameObject();
			e_levels[i].name = "Energy Level " + i;
			e_levels[i].transform.parent = gameObject.transform;
			e_levels[i].AddComponent<LineRenderer>();
			if(Application.loadedLevelName=="Quantum1")
				e_levels[i].AddComponent<tutorialManagerQ>();
			e_levels[i].tag = "EnergyLevel";
			LineRenderer lineRendererE = e_levels[i].GetComponent<LineRenderer>();
			GameObject Elabel = (GameObject)GameObject.Find("E"+i);

//			Elabel.transform.parent = e_levels[i].transform;
			Elabel.transform.position = new Vector3(-4.08f,PsiCalc.energy_set[i]/2 + PsiCalc.yOffset - 0.4f,0.1f);

			lineRendererE.material = m;
			lineRendererE.SetColors(new Color(1,1,1,0.2f),new Color(1,1,1,0.2f));
			lineRendererE.SetWidth(0.02f,0.02f);
			lineRendererE.SetPosition(0, new Vector3(-5,PsiCalc.energy_set[i]/2 + PsiCalc.yOffset,0.1f));
			lineRendererE.SetPosition(1, new Vector3(5, PsiCalc.energy_set[i]/2+ PsiCalc.yOffset,0.1f));
			
		}
		for(int i=0;i<PsiCalc.num_elevel;i++)
		{
			LineRenderer lineRendererE = e_levels[i].GetComponent<LineRenderer>();
			if(i==PsiCalc.E)
			{
				lineRendererE.material = (Material)Resources.Load("Line");
				lineRendererE.SetColors(Color.cyan,Color.cyan);
			}
			
			else
			{
				lineRendererE.material = (Material)Resources.Load("Line");
				lineRendererE.SetColors(new Color(1,1,1,0.8f),new Color(1,1,1,0.8f));
			}
			
		}

	}

}
