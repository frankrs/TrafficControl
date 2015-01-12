using UnityEngine;
using System.Collections;

public class Light_Switch : MonoBehaviour {
	public Animator anim;
	void Start(){ anim =gameObject.GetComponent<Animator>();}
	void OnMouseDown () {anim.SetTrigger("Switch_lights");}
	
}
