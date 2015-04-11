using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

	void OnEnable(){
		GameManager.OnMute += OnMute;
	}

	void OnDisable(){
		GameManager.OnMute -= OnMute;
	}


	void OnAwake(){
		if(StaticClasses.mute){
			audio.Stop();
		}
		else{
			audio.Play();
		}
	}





	void OnMute(){
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
