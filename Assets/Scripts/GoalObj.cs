using UnityEngine;
using System.Collections;

public class GoalObj : MonoBehaviour {

	public delegate void Goal();
	public static event Goal OnGoal;

	void OnTriggerEnter (Collider col) {
		if(col.tag == "Car"){
			col.SendMessageUpwards("OnGoal");
			OnGoal();
		}
	}
	

}
