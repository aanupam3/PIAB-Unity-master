using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	private float rightBound;
	private float leftBound;
	private float bottomBound;
	private float topBound;
	private Vector3 pos;
	private Transform target;
	private SpriteRenderer spriteBounds;

	void Start () {



		
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (target.position.x);
		//Debug.Log (spriteBounds.sprite.bounds.size.x);
		if(tutorialManager.i>=9 && Application.loadedLevelName == "classical")
		{
			float vertExtent = Camera.main.orthographicSize;  
			float horzExtent = vertExtent * Screen.width / Screen.height;
			spriteBounds = GameObject.Find("BG (1)").GetComponentInChildren<SpriteRenderer>();
			target = GameObject.FindWithTag("Player").transform;
			player = GameObject.FindGameObjectWithTag("Player");
			
			leftBound = -spriteBounds.sprite.bounds.size.x+0.2f;//(float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
			rightBound = -0.2f;
//			//rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
//			Vector3 pos = new Vector3(target.position.x, transform.position.y, transform.position.z);
//			pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
//			//pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
//			transform.position = pos;
			Vector3 pos = new Vector3(Mathf.Lerp (transform.position.x,target.position.x,0.1f), transform.position.y, transform.position.z);
			pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
			//pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
			transform.position = pos;
		}
		else if(Application.loadedLevelName == "TransitionLevel")
		{
			float horzExtent = Camera.main.orthographicSize;
			float vertExtent = horzExtent * Screen.height / Screen.width;  

			spriteBounds = GameObject.Find("BG").GetComponentInChildren<SpriteRenderer>();
			target = GameObject.FindWithTag("Player").transform;
			player = GameObject.FindGameObjectWithTag("Player");
			
			topBound = spriteBounds.sprite.bounds.size.y/2-1.1f;//(float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
			bottomBound = -spriteBounds.sprite.bounds.size.y/2+1.1f;
			Vector3 pos = new Vector3(transform.position.x, Mathf.Lerp (transform.position.y,target.position.y,0.1f), transform.position.z);
			pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
			//pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
			transform.position = pos;
		}


	
	}
}
