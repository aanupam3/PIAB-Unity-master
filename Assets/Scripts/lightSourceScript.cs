using UnityEngine;
using System.Collections;

public class lightSourceScript : MonoBehaviour {
	
	// Use this for initialization
	public int totalWeights = 3;
	public int weightsCollected = 0;
	string[] PhotonArray;
	string[] colorArray;
	Color[] colorNameArray;
	float[] EnergyDiffArray;
	float[] initPosArray;
	
	void Start () {
		//gameObject.transform.position = new Vector2(-4.51f,-0.58f);
		weightsCollected = 0;
		EnergyDiffArray = new float[PsiCalc.energy_set.Length-1];
		for(int i=0; i<PsiCalc.energy_set.Length-1;i++)
		{
			EnergyDiffArray[i] = PsiCalc.energy_set[i+1] - PsiCalc.energy_set[i];
		}
		PhotonArray = new string[EnergyDiffArray.Length];
		//colorNameArray = new Color[colorArray.Length];

		if(Application.loadedLevelName == "Quantum1")
		{
			colorArray = new string[]{"QweightRed","QweightGreen","QweightBlue"};
			colorNameArray = new Color[]{new Color(234/255f,131/255f,132/255f),new Color(161/255f,255/255f,159/255f),new Color(84/255f,214/255f,255/255f)};
			//Green : 161,255,159
			//Blue: 84,214,255
			//Red: 234,131,132
		}
		if(Application.loadedLevelName == "Quantum1a")
		{
			colorArray = new string[]{"QweightGreen","QweightRed","QweightBlue"};
			colorNameArray = new Color[]{new Color(161/255f,255/255f,159/255f),new Color(234/255f,131/255f,132/255f),new Color(84/255f,214/255f,255/255f)};
			//Green : 161,255,159
			//Blue: 84,214,255
			//Red: 234,131,132
		}
		if(Application.loadedLevelName == "Quantum2")
		{
			colorArray = new string[]{"QweightRed","QweightGreen","QweightBlue"};
			colorNameArray = new Color[]{Color.red,Color.green,Color.blue};
		}
		//
		initPosArray = new float[colorArray.Length];

//		for(int i=0;i<colorArray.Length;i++)
//		{
//			colorNameArray[i] = colorArray[i].Substring(7).ToLower();
//			Debug.Log(colorNameArray[i]);
//		}
		totalWeights = colorArray.Length;
		for(int i=0;i<initPosArray.Length;i++)
		{
			initPosArray[i] = GameObject.Find(colorArray[i]).transform.position.x;
		}
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if(colorArray.Length == 0 && weightsCollected == totalWeights)
//		{
//			Application.LoadLevel(Application.loadedLevel+1);
//		}
		//		Debug.Log(colorArray[0]);
		GetComponentInChildren<Animator>().ResetTrigger("lightRay");
	}
	
	void OnTriggerStay2D(Collider2D other) 
	{

		if(other.name == colorArray[0])
		{
			Destroy(other.gameObject);
			GameObject lightRay = GameObject.Find("LightRay");
			//Debug.Log (lightRay.GetComponent<Animator>());

			lightRay.GetComponent<Animator>().SetTrigger("lightRay");
			Color c = colorNameArray[0];
			lightRay.GetComponent<SpriteRenderer>().color = c;
			colorArray = ArrayTools.Pop(colorArray);
			colorNameArray = ArrayTools.Pop(colorNameArray);
			initPosArray = ArrayTools.Pop(initPosArray);
			if(tutorialManagerQ.i==13)
			{
				
				tutorialManagerQ.i++;
				GameObject.FindGameObjectWithTag("InstructionText").GetComponent<textQ>().assignText();
				
			}
			PsiCalc.E++;
			PsiCalc.calcSignal = true;
			weightsCollected++;	
			
			
		}
		else
		{
			other.gameObject.GetComponent<weightScript>().picked = false;
			for(int i=0;i<initPosArray.Length;i++)
			{
				if(colorArray[i]== other.gameObject.name)
				{
					
					other.gameObject.transform.position = new Vector2(initPosArray[i],other.gameObject.transform.position.y);
				}
			}
			
		}
	}
	
}
