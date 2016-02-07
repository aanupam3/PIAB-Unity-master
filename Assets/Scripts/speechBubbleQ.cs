using UnityEngine;
using System.Collections;

public class speechBubbleQ : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetTrigger("instructionOpen");
		anim.ResetTrigger("instructionClose");
	}
	
	// Update is called once per frame
	void Update () {
//		if(tutorialManager.i==0)
//		{
//			anim.SetTrigger("instructionOpen");
//			anim.ResetTrigger("instructionClose");
//		}
//			
//		if(tutorialManager.i==10)
//		{
//			anim.ResetTrigger("instructionOpen");
//			anim.SetTrigger("instructionClose");
//		}
//			
	
	}
}
