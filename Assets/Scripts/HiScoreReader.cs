using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScoreReader : MonoBehaviour {

	public Text hiScoreText;


	void Start () {
		if(PlayerPrefs.HasKey("HiScore")){
			hiScoreText.text = PlayerPrefs.GetInt("HiScore").ToString();
		}
		else{
			hiScoreText.text = "NO SCORES SET";
		}
	}
	

}
