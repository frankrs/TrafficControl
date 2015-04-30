using UnityEngine;
using System.Collections;

public class AccidentRef : MonoBehaviour {

	public int a;

	void OnEnable () {
		Car.OnCrash += Crash;
		//CarFactory.OnJam += OnJam;
		//GoalObj.OnGoal += OnGoal;
	}
	
	
	
	void OnDisable () {
		Car.OnCrash -= Crash;
		//CarFactory.OnJam -= OnJam;
		//GoalObj.OnGoal -= OnGoal;
	}


	void Crash(){
		a = (PlayerPrefs.GetInt("Accidents")+1);
		PlayerPrefs.SetInt("Accidents",a);
		if(a == 50){
			gameObject.SendMessage("Achievment","ACCIDENT PRONE");
		}
		if(a == 100){
			gameObject.SendMessage("Achievment","DEMOLITION DERBY");
		}
	}

}
