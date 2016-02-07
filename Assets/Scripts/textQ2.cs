﻿using UnityEngine;
using System.Collections;

public class textQ2 : MonoBehaviour {

	Animator anim;
	SpriteRenderer spr;
	TextMesh T;
	//public int i=0;
	public static bool fade = false;
	string[] instructions;
	int length = 50;
	//public static bool fade = false;
	void Start () {
		fade = false;
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		T = GetComponent<TextMesh>();
		//		spr.color = Color.red;
		//		Debug.Log(spr.color);
		//gameObject.GetComponent<Rigidbody2D>().simulated = false;
		instructions = new string[]{
			"Welcome to the Quantum world. Things behave very differently here.", 
			"This is an electron in it's wave state...",
			"To see the electron in it's particle state, we need to take measurements. At each measurement we can see where the electron had been.",
			"Notice that the electron only appears along the wire. That's because this is a 1-D quantum well. That also means you can't jump.",
			"Let's speed things up a little and see where the electron occurs most.",//3
			"The maximum amplitude of the wave at any point tells us the probability of finding the electron there.",
			"So at all times, the electron has the highest chance of being found in the middle...",
			"...and the least chance at the ends",//6
			"The shape of the wave function is determined by the potential profile.",
			"The electron's total Energy is quantized in this world, which means it can only have discrete values.",
			"The electron is currently on the ground state (Energy Level 0)",//9
			"These are photons of light. Photons can give energy to the electron",//10
			"The color of the photon determines its energy. Lower wavelength (like blue and violet) means higher energy and vice-versa.",
			"Only the correct energy photon can change the electon's energy level. Bring the photons in the right order to the light machine.",
			"The total energy has increased. The wavefunction changes for each energy level, so it now looks different.",//13
			"It now has a node, a point where there is no chance of the electron appearing. he number of nodes is equal to the energy level number  ",
			"Get the remaining photons to finish the level "," "};

		T.text = instructions[tutorialManagerQ.i];
		T.text = ResolveTextSize(T.text,length);
		//Debug.Log(T.text);
		
	}
	

	public void assignText()
	{

		T.text = instructions[tutorialManagerQ.i];
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
