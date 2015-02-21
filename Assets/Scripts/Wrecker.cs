using UnityEngine;
using System.Collections;

public class Wrecker : MonoBehaviour {

	public LayerMask carLayer;

	//private 
	
	void Update () {

//#if UNITY_ANDROID

//#else
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f)),out hit,Mathf.Infinity,carLayer)){
				hit.collider.SendMessageUpwards("OnWrecker");
			 }
		}

//#endif

	}
}
