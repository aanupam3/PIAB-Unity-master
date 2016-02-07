using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class boltFade : MonoBehaviour {
	
	// Use this for initialization
	Animator anim;
	SpriteRenderer spr;
	public static bool bolt = false;
	//public static bool fade = false;
	void Start () {
		
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		anim.ResetTrigger("boltFade");
		bolt = false;
		//		spr.color = Color.red;
		//		Debug.Log(spr.color);
		//gameObject.GetComponent<Rigidbody2D>().simulated = false;
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(bolt)
		{
			anim.SetTrigger("boltFade");
		}
		
		
		
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Particle")
		{
			tutorialManager.i++;
			GameObject.FindGameObjectWithTag("InstructionText").GetComponent<text>().assignText();

			//t.assignText();
		}
	
	}
}
