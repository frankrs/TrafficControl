using UnityEngine;
using System.Collections;

public class SafariSUV : MonoBehaviour {

	void OnGoal () {
		if(PlayerPrefs.GetInt("Safari") >= 50){
			return;
		}
		PlayerPrefs.SetInt("Safari",(PlayerPrefs.GetInt("Safari")+1));
		if(PlayerPrefs.GetInt("Safari") == 50){
			GameObject.FindGameObjectWithTag("manager").SendMessage("Achievment","SAFARI");
		}
	}
}
