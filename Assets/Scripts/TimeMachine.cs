using UnityEngine;
using System.Collections;

public class TimeMachine : MonoBehaviour {
	
	void OnGoal () {
		if(PlayerPrefs.GetInt("GreatScott") >= 8){
			return;
		}
		PlayerPrefs.SetInt("GreatScott",(PlayerPrefs.GetInt("GreatScott")+1));
	}

}
