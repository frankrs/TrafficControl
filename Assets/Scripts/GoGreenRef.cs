using UnityEngine;
using System.Collections;

public class GoGreenRef : MonoBehaviour {

	
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
			if(PlayerPrefs.GetInt("GREEN1") == 1){
				isLevelComplete = true;
			}
			break;
		case 3 :
			if(PlayerPrefs.GetInt("GREEN2") == 1){
				isLevelComplete = true;
			}
			break;
		case 4 : 
			if(PlayerPrefs.GetInt("GREEN3") == 1){
				isLevelComplete = true;
			}
			break;
		}
	}
	
	
	void OnLight(){
		if(isLevelComplete){
			return;
		}
		int gLights = 0;
		foreach (GameObject go in lights){
			if(go.GetComponent<Light_Switch>().lightState == LightState.Green){
				gLights ++;
			}
		}
		if(gLights == lights.Length){
			isLevelComplete = true;
			
			switch (level){
			case 2 :
				PlayerPrefs.SetInt("GREEN1",1);
				break;
			case 3 :
				PlayerPrefs.SetInt("GREEN2",1);
				break;
			case 4 : 
				PlayerPrefs.SetInt("GREEN3",1);
				break;
			}
			
			if((PlayerPrefs.GetInt("GREEN1")+PlayerPrefs.GetInt("GREEN2")+PlayerPrefs.GetInt("GREEN3")) == 3){
				gameObject.SendMessage("Achievment","GO GREEN");
			}
		}
	}
}
