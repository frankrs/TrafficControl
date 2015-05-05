using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Facebook;

public class Options : MonoBehaviour {

	public Text gameNormal;
	public Text gameRandom;

	public Text music;
	public Text fx;

	public MusicBox mb;


	public Text l1;
	public Text l2;
	public Text l3;

	public string gameUrl;
	public string gameIconUrl;

	//public bool isInited = false;

	void Start(){



		FB.Init( onInitComplete,null,null);




		if(StaticClasses.gameMode == GameMode.normal){
			gameNormal.text = "NORMAL";
			gameRandom.text = "random";
		}
		else{
			gameNormal.text = "normal";
			gameRandom.text = "RANDOM";
		}




		if(StaticClasses.mute){
			music.text = "music";
		}
		else{
			music.text = "MUSIC";
		}




		if(StaticClasses.muteFX){
			fx.text = "fx";
		}
		else{
			fx.text = "FX";
		}



		if(PlayerPrefs.HasKey("L1")){
			l1.text = PlayerPrefs.GetInt("L1").ToString();
		}

		if(PlayerPrefs.HasKey("L2")){
			l2.text = PlayerPrefs.GetInt("L2").ToString();
		}

		if(PlayerPrefs.HasKey("L3")){
			l3.text = PlayerPrefs.GetInt("L3").ToString();
		}





	}


	public void SwitchMode (int mode) {
		switch(mode){
		case 1:
			StaticClasses.gameMode = GameMode.normal;
			gameNormal.text = "NORMAL";
			gameRandom.text = "random";
			break;
		case 2:
			StaticClasses.gameMode = GameMode.random;
			gameNormal.text = "normal";
			gameRandom.text = "RANDOM";
			break;
		}
	}

	public void MuteMusic() {
		if(StaticClasses.mute == false){
			music.text = "music";
		}
		else{
			music.text = "MUSIC";
		}
		mb.OnMute();
	}


	public void MuteFX (){
		if(StaticClasses.muteFX == false){
			StaticClasses.muteFX = true;
			fx.text = "fx";
		}
		else{
			StaticClasses.muteFX = false;
			fx.text = "FX";
		}
	}

	public void VisitSite(string url){
		Application.OpenURL(url);
	}


	public void onInitComplete(){
		//Debug.Log("inited");
		StaticClasses.fBInited = true;
	}




	public void FBPost (){
		if(FB.IsInitialized && !FB.IsLoggedIn){
			FB.Login("public_profile,user_friends",OnFBLoggedIn);
		}
		else{
			FaceBookFeed();
		}
	}


	public void OnFBLoggedIn(FBResult result){
		FaceBookFeed();
	}

	public void FaceBookFeed (){
		FB.Feed(link: gameUrl,picture: gameIconUrl, linkName: "City Stoplight Simulator");
	}



}
