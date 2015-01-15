using UnityEngine;
using System.Collections;

public class Light_Switch : MonoBehaviour {
	public Animator anim;
	public Collider stopCollider;

	void Start(){ 
		anim = gameObject.GetComponent<Animator>();
	}

	void OnMouseDown () {
		anim.SetTrigger("Switch_lights");
	}

	public void RedLight(){
		stopCollider.enabled = true;
	}

	public void GreenLight (){
		stopCollider.enabled = false;
	}

}
