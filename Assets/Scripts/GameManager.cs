using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;
	public GameSounds gameSounds;

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
		Stats.errors = Stats.errors + 5;
		hudItems.goalMeter.text = Stats.errors.ToString();
	}

	// called when car cant be made due to jam
	void OnJam (){
		Stats.Jams ++;
		Stats.errors = Stats.errors + 1;
		hudItems.stopSignMeter.text = Stats.errors.ToString();
		audio.PlayOneShot(gameSounds.honk);
	}

	void OnGoal (){
		Stats.Goals ++;
		hudItems.goalMeter.text = Stats.Goals.ToString();
	}
}


[System.Serializable]
public class HudItems{
	public Text stopSignMeter;
	public Text goalMeter;
}

[System.Serializable]
public static class Stats{
	public static int Crashes;
	public static int Jams;
	public static int Goals;
	public static int errors;
}


[System.Serializable]
public class GameSounds{
	public AudioClip honk;
}
