using UnityEngine;
using System.Collections;

public class Wrecker : MonoBehaviour {

	public LayerMask carLayer;
	public AudioClip[] wreckerSounds;

	//private 
	
	void Update () {

//#if UNITY_ANDROID

//#else
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.SphereCast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f)),1f,out hit,Mathf.Infinity,carLayer)){
				hit.collider.SendMessageUpwards("OnWrecker",wreckerSounds);
				//audio.PlayOneShot(wreckerSound);
			 }
		}

//#endif

	}
}
