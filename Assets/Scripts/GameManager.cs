using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;


	// subscribe to events
	void OnEnable () {
		Car.OnCrash += Crash;
	}

	void OnDisable () {
		Car.OnCrash -= Crash;
	}



	// Called whenever car crashes
	void Crash () {
		Stats.Crashes ++;
		hudItems.crashesMeter.text = Stats.Crashes.ToString();
	}
}


[System.Serializable]
public class HudItems{
	public Text crashesMeter;
}

[System.Serializable]
public static class Stats{
	public static int Crashes;
}