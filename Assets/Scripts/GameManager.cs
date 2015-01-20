using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;


	// subscribe to events
	void OnEnable () {
		Car.OnCrash += Crash;
		CarFactory.OnJam += OnJam;
	}

	void OnDisable () {
		Car.OnCrash -= Crash;
		CarFactory.OnJam -= OnJam;
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
}


[System.Serializable]
public class HudItems{
	public Text crashesMeter;
	public Text jamMeter;
}

[System.Serializable]
public static class Stats{
	public static int Crashes;
	public static int Jams;
}