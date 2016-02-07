using UnityEngine;
using System.Collections;

public class text : MonoBehaviour {

	Animator anim;
	SpriteRenderer spr;
	TextMesh T;
	//public int i=0;
	public static bool fade = false;
	string[] instructions;
	int length = 55;
	//public static bool fade = false;
	void Start () {
		
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		T = GetComponent<TextMesh>();
		//		spr.color = Color.red;
		//		Debug.Log(spr.color);
		//gameObject.GetComponent<Rigidbody2D>().simulated = false;
		instructions = new string[]{
			"Welcome to the ideal classical world. The surface here is frictionless and there is no energy loss. ",
			"Let’s say the ball has some initial velocity, what will happen?",//1
			"The ball will keep oscillating back and forth forever.",//2
			"We know where the ball is and we can predict where it will be next.",//3
			"Let's talk about its energy. The Potential Energy of the ball is directly related to its height.",//4
			"The Total Energy stays constant unless the ball is given energy.",//5
			"The red line represents Kinetic Energy and it is the difference between the Total Energy and Potential Energy.",//6
			"Use left and right arrow keys to get to the energy bolt. Spacebar to jump. Up arrow to pick up and drop the bolt. Feed this bolt to the ball by placing it in the ball’s path.",
			"Adding more energy increases the Kinetic and therefore the Total Energy of the ball. Press next and head through the door to play the next level.",
			" "};

		T.text = instructions[tutorialManager.i];
		T.text = ResolveTextSize(T.text,length);
		//Debug.Log(T.text);
		
	}
	

	public void assignText()
	{
		T.text = instructions[tutorialManager.i];
		T.text = ResolveTextSize(T.text,length);
	}
	private string ResolveTextSize(string input, int lineLength){
		
		// Split string by char " "         
		string[] words = input.Split(" "[0]);
		
		// Prepare result
		string result = "";
		
		// Temp line string
		string line = "";
		
		// for each all words        
		foreach(string s in words){
			// Append current word into line
			string temp = line + " " + s;
			
			// If line length is bigger than lineLength
			if(temp.Length > lineLength){
				
				// Append current line into result
				result += line + "\n";
				// Remain word append into new line
				line = s;
			}
			// Append current word into current line
			else {
				line = temp;
			}
		}
		
		// Append last line into result        
		result += line;
		
		// Remove first " " char
		return result.Substring(1,result.Length-1);
	}
}
