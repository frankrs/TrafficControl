using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievmentsMenu : MonoBehaviour {

	public GreatScott greatScott;
	public CrossingGuard crossingGuard;
	public RedAlert redAlert;
	public GoGreen goGreen;
	public AccidentProne accidentProne;
	public Demolition demolition;
	public MonringRushHour morningRushHour;
	public NoonRushHour noonRushHour;
	public FiveRushHour fiveRushHour;
	public Safari safari;



	void Awake () {
		// if level is main menu save player prefs get or create pref keys and then store the static variablies
		if(Application.loadedLevel == 0){
			PlayerPrefs.Save();
			SetOrGetKeys();
		}

	}
	


	void SetOrGetKeys (){
		GreatScott();
		CrossingGaurd();
		RedAlert();
		GoGreen();
		AccidentProne();
		RushHour ();
		Safari();
		PlayerPrefs.Save();
	}


	void GreatScott(){
		if(PlayerPrefs.HasKey("GreatScott")){
			//Debug.Log("has key");
			if(PlayerPrefs.GetInt("GreatScott") >= 88){
				greatScott.trophy.gameObject.SetActive(true);
				greatScott.stats.gameObject.SetActive(false);
			}
			else{
				greatScott.stats.text = PlayerPrefs.GetInt("GreatScott").ToString()+"/88";
			}
		}
		else{
			//Debug.Log("no key");
			PlayerPrefs.SetInt("GreatScott",0);
		}
	}


	void CrossingGaurd (){
		if(PlayerPrefs.HasKey("CrossingGuard")){
			//Debug.Log("has key");
			if(PlayerPrefs.GetInt("CrossingGuard") == 1){
				crossingGuard.trophy.gameObject.SetActive(true);
				//crossingGuard.stats.gameObject.SetActive(false);
			}
		}
		else{
			PlayerPrefs.SetInt("CrossingGuard",0);
		}
	}




	void RedAlert (){
		if(PlayerPrefs.HasKey("RED1")){
			//Debug.Log("has key");
			int levelsum = (PlayerPrefs.GetInt("RED1") + PlayerPrefs.GetInt("RED2") + PlayerPrefs.GetInt("RED3"));
			if( levelsum == 3){
				redAlert.trophy.gameObject.SetActive(true);
				redAlert.stats.gameObject.SetActive(false);
			}
			else{
				redAlert.stats.text = levelsum.ToString()+"/3";
			}
		}
		else{
			//Debug.Log("no key");
			PlayerPrefs.SetInt("RED1",0);
			PlayerPrefs.SetInt("RED2",0);
			PlayerPrefs.SetInt("RED3",0);
		}

	}


	void GoGreen (){
		if(PlayerPrefs.HasKey("GREEN1")){
			//Debug.Log("has key");
			int levelsum = (PlayerPrefs.GetInt("GREEN1") + PlayerPrefs.GetInt("GREEN2") + PlayerPrefs.GetInt("GREEN3"));
			if( levelsum == 3){
				goGreen.trophy.gameObject.SetActive(true);
				goGreen.stats.gameObject.SetActive(false);
			}
			else{
				goGreen.stats.text = levelsum.ToString()+"/3";
			}
		}
		else{
			//Debug.Log("no key");
			PlayerPrefs.SetInt("GREEN1",0);
			PlayerPrefs.SetInt("GREEN2",0);
			PlayerPrefs.SetInt("GREEN3",0);
		}
		
	}


	void AccidentProne(){
		if(PlayerPrefs.HasKey("Accidents")){
			//Debug.Log("has key");

			if(PlayerPrefs.GetInt("Accidents") >= 50){
				accidentProne.trophy.gameObject.SetActive(true);
				accidentProne.stats.gameObject.SetActive(false);
			}
			else{
				accidentProne.stats.text = PlayerPrefs.GetInt("Accidents").ToString()+"/50";
			}

			if(PlayerPrefs.GetInt("Accidents") >= 100){
				demolition.trophy.gameObject.SetActive(true);
				demolition.stats.gameObject.SetActive(false);
			}
			else{
				demolition.stats.text = PlayerPrefs.GetInt("Accidents").ToString()+"/100";
			}

		}
		else{
			//Debug.Log("no key");
			PlayerPrefs.SetInt("Accidents",0);
		}
	}



	void RushHour (){
		if(PlayerPrefs.HasKey("RushHour1")){
			//Debug.Log("has key");
			if(PlayerPrefs.GetInt("RushHour1") == 1){
				morningRushHour.trophy.gameObject.SetActive(true);
				//crossingGuard.stats.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("RushHour2") == 1){
				noonRushHour.trophy.gameObject.SetActive(true);
				//crossingGuard.stats.gameObject.SetActive(false);
			}
			if(PlayerPrefs.GetInt("RushHour3") == 1){
				fiveRushHour.trophy.gameObject.SetActive(true);
				//crossingGuard.stats.gameObject.SetActive(false);
			}
		}
		else{
			PlayerPrefs.SetInt("RushHour1",0);
			PlayerPrefs.SetInt("RushHour2",0);
			PlayerPrefs.SetInt("RushHour3",0);
		}
	}


	void Safari(){
		if(PlayerPrefs.HasKey("Safari")){
			//Debug.Log("has key");
			if(PlayerPrefs.GetInt("Safari") >= 50){
				safari.trophy.gameObject.SetActive(true);
				safari.stats.gameObject.SetActive(false);
			}
			else{
				safari.stats.text = PlayerPrefs.GetInt("Safari").ToString()+"/50";
			}
		}
		else{
			//Debug.Log("no key");
			PlayerPrefs.SetInt("Safari",0);
		}
	}



}

[System.Serializable]
public class GreatScott {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class CrossingGuard {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class RedAlert {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class GoGreen {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class AccidentProne {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class Demolition {
	public Text stats;
	public Image trophy;
}


[System.Serializable]
public class MonringRushHour {
	public Text stats;
	public Image trophy;
}


[System.Serializable]
public class NoonRushHour {
	public Text stats;
	public Image trophy;
}

[System.Serializable]
public class FiveRushHour {
	public Text stats;
	public Image trophy;
}


[System.Serializable]
public class Safari {
	public Text stats;
	public Image trophy;
}