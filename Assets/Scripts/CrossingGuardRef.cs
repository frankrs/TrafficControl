using UnityEngine;
using System.Collections;

public class CrossingGuardRef : MonoBehaviour {

	public int carsPassed;

	void OnEnable () {
		Car.OnCrash += Crash;
		//CarFactory.OnJam += OnJam;
		GoalObj.OnGoal += Goal;
	}
	
	
	
	void OnDisable () {
		Car.OnCrash -= Crash;
		//CarFactory.OnJam -= OnJam;
		GoalObj.OnGoal -= Goal;
	}

	void Crash () {
		carsPassed = 0;
	}

	void Goal (){
		if(PlayerPrefs.GetInt("CrossingGuard") == 1){
			return;
		}
		carsPassed++;
		if(carsPassed == 20){
			PlayerPrefs.SetInt("CrossingGuard",1);
			gameObject.SendMessage("Achievment","CROSSING GUARD");
		}
	}

}
