using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;


	// subscribe to events
	void OnEnable () {
		Car.OnCrash += Crash;
		CarFactory.OnJam += OnJam;
		GoalObj.OnGoal += OnGoal;
	}



	void OnDisable () {
		Car.OnCrash -= Crash;
		CarFactory.OnJam -= OnJam;
		GoalObj.OnGoal -= OnGoal;
	}



	// Called whenever car crashes
	void Crash () {
		Stats.Crashes ++;
		hudItems.crashesMeter.text = Stats.Crashes.ToString();
	}

	// called when car cant be made due to jam
	void OnJam (){
		Stats.Jams ++;
		hudItems.jamMeter.text = Stats.Jams.ToString();
	}

	void OnGoal (){
		Stats.Goals ++;
		hudItems.goalMeter.text = Stats.Goals.ToString();
	}
}


[System.Serializable]
public class HudItems{
	public Text crashesMeter;
	public Text jamMeter;
	public Text goalMeter;
}

[System.Serializable]
public static class Stats{
	public static int Crashes;
	public static int Jams;
	public static int Goals;
}