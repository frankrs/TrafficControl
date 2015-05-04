using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using ChartboostSDK;

public class GameManager : MonoBehaviour {

	public HudItems hudItems;
	public GameSounds gameSounds;


	public delegate void Mute();
	public static event Mute OnMute;


	static public GameManager crt; //the instance of our class that will do the work
	
	void Awake(){ //called when an instance awakes in the game
		crt = this; //set our static reference to our newly initialized instance
	}
	

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




	void Start(){
		HZInterstitialAd.setDisplayListener(listener);
		Stats.ResetStats();
		PlayIntAd();
		//UnPause();
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


	static public void Pause(){
		Time.timeScale = 0f;
		crt.StopCoroutine("KeepTime");
	}

	static public void UnPause(){
		Time.timeScale = 1f;
		crt.StartCoroutine("KeepTime");
	}

	public void PauseB (){
		Pause();
	}

	public void UnPauseB (){
		UnPause();
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


		///
		switch(Application.loadedLevel){

			case 2 :
				if(PlayerPrefs.GetInt("L1") < Stats.Goals){
				PlayerPrefs.SetInt("L1", Stats.Goals);
				NewHi();
			}
			break;

		case 3 :
			if(PlayerPrefs.GetInt("L2") < Stats.Goals){
				PlayerPrefs.SetInt("L2", Stats.Goals);
				NewHi();
			}
			break;


		case 4 :
			if(PlayerPrefs.GetInt("L3") < Stats.Goals){
				PlayerPrefs.SetInt("L3", Stats.Goals);
				NewHi();
			}
			break;
	
		}

	}


	void NewHi(){
		//PlayerPrefs.SetInt("HiScore",Stats.Goals);
		hudItems.gameOver.HiScoreSign.SetActive(true);
		hudItems.gameOver.HiScoreText.text = Stats.Goals.ToString();
	}



	public void MuteButton(){
		OnMute();
	}


	public void Achievment (string ach){
		Pause();
		if(StaticClasses.muteFX == false){
		audio.PlayOneShot(gameSounds.achievment);
		}
		hudItems.achievmentLabel.text = ach;
		hudItems.achievmentPannel.SetActive(true);

	}


	public void AchievmentResume () {
		//hudItems.achievmentPannel.SetActive(false);
//		if(Chartboost.hasInterstitial(CBLocation.Default)){
//			Chartboost.showInterstitial(CBLocation.Default);
//		}
		PlayIntAd();
		//UnPause();
	}



	public void PlayIntAd(){
		if(HZInterstitialAd.isAvailable()){
		HZInterstitialAd.show();
		}
		else{
			UnPause();
		}
	}




	HZInterstitialAd.AdDisplayListener listener = delegate(string adState, string adTag){
		if ( adState.Equals("show") ) {
			Pause ();
			// Do something when the ad shows, like pause your game
		}
		if ( adState.Equals("hide") ) {
			UnPause();
			// Do something after the ad hides itself
		}
		if ( adState.Equals("click") ) {
			// Do something when an ad is clicked on
		}
		if ( adState.Equals("failed") ) {
			UnPause ();
			// Do something when an ad fails to show
		}
		if ( adState.Equals("available") ) {
			// Do something when an ad has successfully been fetched
		}
		if ( adState.Equals("fetch_failed") ) {
			// Do something when an ad did not fetch
		}
		if ( adState.Equals("audio_starting") ) {
			// The ad being shown will use audio. Mute any background music
		}
		if ( adState.Equals("audio_finished") ) {
			// The ad being shown has finished using audio.
			// You can resume any background music.
		}
	};






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

