using UnityEngine;
using System.Collections;

public class TimeMachine : MonoBehaviour {
	
	void OnGoal () {
		if(PlayerPrefs.GetInt("GreatScott") >= 88){
			return;
		}
		PlayerPrefs.SetInt("GreatScott",(PlayerPrefs.GetInt("GreatScott")+1));
		if(PlayerPrefs.GetInt("GreatScott") == 88){
			GameObject.FindGameObjectWithTag("manager").SendMessage("Achievment","GREAT SCOTT");
		}
	}

}
