using UnityEngine;
using System.Collections;

public class Light_Switch : MonoBehaviour {
	public Animator anim;
	public BoxCollider[] stopColliders;
	public LightState lightState;
	public TimerSwitch timerSwitch;

	public AudioClip ding;



	public delegate void LightChange();
	public static event LightChange OnLightChange;






	void OnDrawGizmos(){
		if(stopColliders.Length == 0){
			return;
		}

	switch(lightState){
		case LightState.Red:
		Gizmos.color = new Color(1, 0, 0, 0.5F);
		break;

		case LightState.Green:
		Gizmos.color = new Color(0, 1, 0, 0.5F);
		break;
	}
		Gizmos.DrawCube(stopColliders[0].transform.position + stopColliders[0].center, stopColliders[0].size);
		Gizmos.DrawLine(transform.position,stopColliders[0].transform.position + stopColliders[0].center);
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
	
		// monkey with the switch
		// start switching at random
		StartCoroutine("RandomSwitch");
	}



	void OnMouseDown () {

		AudioSource.PlayClipAtPoint(ding,new Vector3(0,0,0));

		SwitchLights();
		StopCoroutine("RandomSwitch");
		StartCoroutine("RandomSwitch");
	}

	void SwitchLights() {
		anim.SetTrigger("Switch_lights");
	}

	IEnumerator RandomSwitch() {
		yield return new WaitForSeconds(SetRandomTime());
		SwitchLights();
		// call again from self
		StartCoroutine("RandomSwitch");
	}

	float SetRandomTime(){
		return  Random.Range(timerSwitch.minTime,timerSwitch.maxTime);
	}


	public void RedLight(){
		foreach(BoxCollider bc in stopColliders){
			bc.enabled = true;
		}
		lightState = LightState.Red;
		OnLightChange();
	}

	public void GreenLight (){
		foreach(BoxCollider bc in stopColliders){
			bc.enabled = false;
		}
		lightState = LightState.Green;
		OnLightChange();
	}

}

[System.Serializable]
public enum LightState{
	Red,Green
}



[System.Serializable]
public class TimerSwitch{
	public float minTime = 5f;
	public float maxTime = 21f;
}




