using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievmentsMenu : MonoBehaviour {

	public GreatScott greatScott;

	void Awake () {
		// if level is main menu save player prefs get or create pref keys and then store the static variablies
		if(Application.loadedLevel == 0){
			PlayerPrefs.Save();
			SetOrGetKeys();
		}

	}
	


	void SetOrGetKeys (){
		GreatScott();
		PlayerPrefs.Save();
	}


	void GreatScott(){
		if(PlayerPrefs.HasKey("GreatScott")){
			Debug.Log("has key");
			if(PlayerPrefs.GetInt("GreatScott") >= 8){
				greatScott.trophy.gameObject.SetActive(true);
				greatScott.stats.gameObject.SetActive(false);
			}
			else{
				greatScott.stats.text = PlayerPrefs.GetInt("GreatScott").ToString()+"/8";
			}
		}
		else{
			Debug.Log("no key");
			PlayerPrefs.SetInt("GreatScott",0);
		}
	}


}

[System.Serializable]
public class GreatScott {
	public Text stats;
	public Image trophy;
}



