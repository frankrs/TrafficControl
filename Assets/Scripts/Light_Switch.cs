using UnityEngine;
using System.Collections;

public class Light_Switch : MonoBehaviour {
	public Animator anim;
	public BoxCollider stopCollider;
	public LightState lightState;


	void OnDrawGizmos(){
	switch(lightState){
		case LightState.Red:
		Gizmos.color = new Color(1, 0, 0, 0.5F);
		break;

		case LightState.Green:
		Gizmos.color = new Color(0, 1, 0, 0.5F);
		break;
	}
		Gizmos.DrawCube(stopCollider.transform.position + stopCollider.center, stopCollider.size);
		Gizmos.DrawLine(transform.position,stopCollider.transform.position + stopCollider.center);
	}


	void Start(){ 
		anim = gameObject.GetComponent<Animator>();

		switch(lightState){
		case LightState.Red:
			anim.SetTrigger("Red");
			break;
			
		case LightState.Green:
			anim.SetTrigger("Green");
			break;
		}

	}

	void OnMouseDown () {
		anim.SetTrigger("Switch_lights");
	}

	public void RedLight(){
		stopCollider.enabled = true;
		lightState = LightState.Red;
	}

	public void GreenLight (){
		stopCollider.enabled = false;
		lightState = LightState.Green;
	}

}

[System.Serializable]
public enum LightState{
	Red,Green
}
