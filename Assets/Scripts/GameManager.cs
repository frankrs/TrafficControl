using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;
	public GameSounds gameSounds;




	void Start (){

	}

//	IEnumerator KeepTime (){
//
//	}


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


	void OnLevelWasLoaded(){
		Stats.ResetStats();
		UnPause();
	}

	// Called whenever car crashes
	void Crash () {
		Stats.Crashes ++;
		Stats.errors = Stats.errors + 5;
		hudItems.stopSignMeter.text = Stats.errors.ToString();
		CheckForGameOver();
	}

	// called when car cant be made due to jam
	void OnJam (){
		Stats.Jams ++;
		Stats.errors = Stats.errors + 1;
		hudItems.stopSignMeter.text = Stats.errors.ToString();
		audio.PlayOneShot(gameSounds.honk);
		CheckForGameOver();
	}

	void OnGoal (){
		Stats.Goals ++;
		hudItems.goalMeter.text = Stats.Goals.ToString();
	}


	public void Pause(){
		Time.timeScale = 0f;
	}

	public void UnPause(){
		Time.timeScale = 1f;
	}



	public void CheckForGameOver(){
		if(Stats.errors > hudItems.gameOver.errorLimit){
			GameOver();
		}
	}

	public void GameOver(){
		Time.timeScale = 0f;
		hudItems.gameOver.gameOverScreen.SetActive(true);
		hudItems.gameOver.crashes.text = Stats.Crashes.ToString();
		hudItems.gameOver.time = 
	}


}


[System.Serializable]
public class HudItems{
	public Text stopSignMeter;
	public Text goalMeter;
	public GameOver gameOver;
}

[System.Serializable]
public static class Stats{
	public static int Crashes;
	public static int Jams;
	public static int Goals;
	public static int errors;
	public static float gameTime;

	public static void ResetStats(){
		Crashes = 0;
		Jams = 0;
		Goals = 0;
		errors = 0;
		gameTime = 0f;
	}
}


[System.Serializable]
public class GameSounds{
	public AudioClip honk;
}

[System.Serializable]
public class GameOver{
	public int errorLimit = 50;
	public GameObject gameOverScreen;
	public Text crashes;
	public Text time;
}

