using UnityEngine;
using System.Collections;

public class chargesMotion : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	SpriteRenderer spr ;
	void Start()
	{
		spr = gameObject.GetComponent<SpriteRenderer>();
	}
//	void OnMouseDown()
//	{
//		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//		
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//		
//	}
//	
//	void OnMouseDrag()
//	{
//		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//		
//		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
//		if(curPosition.x>PsiCalc.xmax)
//			curPosition.x = PsiCalc.xmax;
//		if(curPosition.x<PsiCalc.xmin)
//			curPosition.x = PsiCalc.xmin;
//		transform.position = curPosition;
//		
//	}
	void OnMouseDrag()
	{
		//Debug.Log(spr.bounds.ClosestPoint(Input.mousePosition).x);
		//Debug.Log (spr.bounds);
		//Debug.Log (Camera.main.ScreenToWorldPoint(Input.mousePosition));

//		if(spr.bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0))))
//		{
			float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
			Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
			if(pos_move.x>PsiCalc.xmax)
				pos_move.x = PsiCalc.xmax;
			if(pos_move.x<PsiCalc.xmin)
				pos_move.x = PsiCalc.xmin;
			transform.position = new Vector3( pos_move.x, transform.position.y, pos_move.z );
		//}
		//Debug.Log (transform.position.x);
		PotentialProfile.dragging = true;
		//Cursor.SetCursor(
		
	}

}

