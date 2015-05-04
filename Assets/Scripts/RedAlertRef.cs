using UnityEngine;
using System.Collections;

public class RedAlertRef : MonoBehaviour {


	public GameObject[] lights;
	public int level;
	public bool isLevelComplete;

	void OnEnable(){
		Light_Switch.OnLightChange += OnLight;
	}

	void OnDisable(){
		Light_Switch.OnLightChange -= OnLight;
	}

	void Awake () {
		lights = GameObject.FindGameObjectsWithTag("clickme");
		level = Application.loadedLevel;
		switch (level){
		case 2 :
			if(PlayerPrefs.GetInt("RED1") == 1){
				isLevelComplete = true;
			}
			break;
		case 3 :
			if(PlayerPrefs.GetInt("RED2") == 1){
				isLevelComplete = true;
			}
			break;
		case 4 : 
			if(PlayerPrefs.GetInt("RED3") == 1){
				isLevelComplete = true;
			}
			break;
		}
	}


	void OnLight(){
		if(isLevelComplete){
			return;
		}
		int rLights = 0;
		foreach (GameObject go in lights){
			if(go.GetComponent<Light_Switch>().lightState == LightState.Red){
				rLights ++;
			}
		}
		if(rLights == lights.Length){
			isLevelComplete = true;
		
			switch (level){
			case 2 :
				PlayerPrefs.SetInt("RED1",1);
				break;
			case 3 :
				PlayerPrefs.SetInt("RED2",1);
				break;
			case 4 : 
				PlayerPrefs.SetInt("RED3",1);
				break;
			}

			if((PlayerPrefs.GetInt("RED1")+PlayerPrefs.GetInt("RED2")+PlayerPrefs.GetInt("RED3")) == 3){
				gameObject.SendMessage("Achievment","RED ALERT");
			}
		}
	}

}
