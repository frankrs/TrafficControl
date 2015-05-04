using UnityEngine;
using System.Collections;

public class RushHourRef : MonoBehaviour {

	public int lev;
	public bool isComp = false;


	void Awake(){
		lev = Application.loadedLevel;


		switch (lev){
		case 2 : 
			if(PlayerPrefs.GetInt("RushHour1") == 1){
				isComp = true;
			}
			break;
		case 3 : 
			if(PlayerPrefs.GetInt("RushHour2") == 1){
				isComp = true;
			}
			break;
		case 4 : 
			if(PlayerPrefs.GetInt("RushHour2") == 1){
				isComp = true;
			}
			break;
		}

	}



	void OnEnable () {
		//Car.OnCrash += Crash;
		//CarFactory.OnJam += OnJam;
		GoalObj.OnGoal += OnGoal;
	}
	
	
	
	void OnDisable () {
		//Car.OnCrash -= Crash;
		//CarFactory.OnJam -= OnJam;
		GoalObj.OnGoal -= OnGoal;
	}


	void OnGoal(){
		if(isComp){
			return;
		}

		switch (lev){
		case 2 : 
			if(Stats.Goals == 1000){
				isComp = true;
				gameObject.SendMessage("Achievment","MORNING RUSH HOUR");
				PlayerPrefs.SetInt("RushHour1",1);
			}
			break;
		case 3 : 
			if(Stats.Goals == 500){
				gameObject.SendMessage("Achievment","NOON RUSH HOUR");
				isComp = true;
				PlayerPrefs.SetInt("RushHour2",1);
			}
			break;
		case 4 : 
			if(Stats.Goals == 250){
				gameObject.SendMessage("Achievment","5 O'CLOCK RUSH HOUR");
				isComp = true;
				PlayerPrefs.SetInt("RushHour3",1);
			}
			break;
		}

	}

}
