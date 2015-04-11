using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

	void OnEnable(){
		GameManager.OnMute += OnMute;
	}

	void OnDisable(){
		GameManager.OnMute -= OnMute;
	}


	void Awake(){
		if(StaticClasses.mute){
			audio.Stop();
		}
		else{
			audio.Play();
		}
	}





	public void OnMute(){
		if(StaticClasses.mute){
			StaticClasses.mute = false;
			audio.Play();
		}
		else{
			StaticClasses.mute = true;
			audio.Stop();
		}
	}
}
