using UnityEngine;
using System.Collections;

public class PlayerShrink : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	GameObject camera1;
	GameObject BG;
	GameObject bar;
	GameObject scale;
	float rate, speed;
	GameObject sF;
	void Start () {
		sF = GameObject.FindGameObjectWithTag("SceneFade");
		player = GameObject.FindGameObjectWithTag("Player");
		camera1 = GameObject.FindGameObjectWithTag("MainCamera");
		BG = GameObject.FindGameObjectWithTag("BG");
		bar = GameObject.Find("Scale_bar");
		scale = GameObject.Find ("Scale");
		rate = 0.005f;//(player.transform.localScale.x - 0.02f)/(Mathf.Sqrt(((2*1.5*(BG.GetComponent<RectTransform>().rect.height))/(player.GetComponent<Rigidbody2D>().gravityScale))));
		//Debug.Log(rate;

	}
	
	// Update is called once per frame
	void Update () {

		player.transform.localScale = new Vector3(player.transform.lossyScale.x-rate,player.transform.lossyScale.y-rate,0f);
		camera1.transform.position = new Vector3(player.transform.position.x, player.transform.position.y-2.5f,camera1.transform.position.z);
//		float barHeight = scale.transform.position.y+scale.GetComponent<SpriteRenderer>().sprite.bounds.extents.y/2;
//		float barHeight = Mathf.Clamp(player.transform.position.y);
		speed=0.4f*Time.timeSinceLevelLoad;
		float barMin = scale.GetComponent<SpriteRenderer>().bounds.center.y-scale.GetComponent<SpriteRenderer>().bounds.extents.y+0.05f;
		float barMax = scale.GetComponent<SpriteRenderer>().bounds.center.y+scale.GetComponent<SpriteRenderer>().bounds.extents.y-0.0f;
		float barHeight = Mathf.Clamp(bar.transform.position.y-speed*Time.deltaTime,barMin,barMax);
		bar.transform.position = new Vector3(bar.transform.position.x,barHeight,transform.position.z);
		Debug.Log(bar.transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			sF.GetComponent<Animator>().SetBool("fadeIn",false);
			sF.GetComponent<Animator>().SetBool("fadeOut",true);
			StartCoroutine(LevelLoad());

		}
	}
	IEnumerator LevelLoad(){
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(Application.loadedLevel+1);
	}
}
