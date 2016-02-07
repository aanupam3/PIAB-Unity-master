using UnityEngine;
using System.Collections;

public class speechBubble : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tutorialManager.i==0)
		{
			anim.SetTrigger("instructionOpen");
			anim.ResetTrigger("instructionClose");
		}
			
		if(tutorialManager.i==10)
		{
			anim.ResetTrigger("instructionOpen");
			anim.SetTrigger("instructionClose");
		}
			
	
	}
}
