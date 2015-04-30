using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ChartboostSDK;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;
	public GameSounds gameSounds;


	public delegate void Mute();
	public static event Mute OnMute;




//	void Start (){
//		//StartCoroutine("KeepTime");
//	}

	IEnumerator KeepTime (){
		while(this){
			Stats.gameTime = Stats.gameTime + Time.deltaTime;
				yield return new WaitForEndOfFrame();
		}
	}


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


//	void OnLevelWasLoaded(){
//		Stats.ResetStats();
//		UnPause();
//	}


		void Start(){
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
		StopCoroutine("KeepTime");
	}

	public void UnPause(){
		Time.timeScale = 1f;
		StartCoroutine("KeepTime");
	}



	public void CheckForGameOver(){
		if(Stats.errors > hudItems.gameOver.errorLimit){
			GameOver();
		}
	}

	public void GameOver(){
		//Time.timeScale = 0f;
		Pause ();
		hudItems.gameOver.gameOverScreen.SetActive(true);
		hudItems.gameOver.crashes.text = Stats.Crashes.ToString();
		//hudItems.gameOver.time = 
		hudItems.gameOver.scoreText.text = "SCORE " + Stats.Goals.ToString();
		hudItems.gameOver.time.text = "TIME TAKEN " + Mathf.RoundToInt(Stats.gameTime).ToString();
		hudItems.gameOver.crashes.text = "CRASHES " + Stats.Crashes.ToString();
		hudItems.gameOver.jams.text = "JAMS " + Stats.Jams.ToString();
		if(PlayerPrefs.HasKey("HiScore")){
			if(PlayerPrefs.GetInt("HiScore") < Stats.Goals){
				NewHi();
			}
		}
		else {
			NewHi ();
		}
	}


	void NewHi(){
		PlayerPrefs.SetInt("HiScore",Stats.Goals);
		hudItems.gameOver.HiScoreSign.SetActive(true);
		hudItems.gameOver.HiScoreText.text = Stats.Goals.ToString();
	}



	public void MuteButton(){
		OnMute();
	}


	public void Achievment (string ach){
		Pause();
		audio.PlayOneShot(gameSounds.achievment);
		hudItems.achievmentLabel.text = ach;
		hudItems.achievmentPannel.SetActive(true);

	}


	public void AchievmentResume () {
		//hudItems.achievmentPannel.SetActive(false);
		if(Chartboost.hasInterstitial(CBLocation.Default)){
			Chartboost.showInterstitial(CBLocation.Default);
		}
		UnPause();
	}

}


[System.Serializable]
public class HudItems{
	public Text stopSignMeter;
	public Text goalMeter;
	public GameObject achievmentPannel;
	public Text achievmentLabel;
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
	public AudioClip achievment;
}

[System.Serializable]
public class GameOver{
	public int errorLimit = 50;
	public GameObject gameOverScreen;
	public Text crashes;
	public Text time;
	public Text jams;
	public Text scoreText;
	public GameObject HiScoreSign;
	public Text HiScoreText;
}

//[System.Serializable]
//public class 

