using UnityEngine;
using System.Collections;
using Facebook;
using System.Collections.Generic;
using System.Linq;

using Facebook;
using Facebook.MiniJSON;

public class Franks_FB_Test : MonoBehaviour {


	public void FBInit () {
		FB.Init(onInitComplete);
		//FB.Init( InitDelegate onInitComplete, HideUnityDelegate hideUnityDelegate = null,string authResponse = null);
	}
	

	public void FBLog () {
		FB.Login("email,publish_actions",null);
	}


	public void FBFeed (){
		FB.Feed();
	}


	public void FBReq(){
		FB.AppRequest(message: "Roger", title: "Is this Working");
	}

	private void onInitComplete (){
		Camera.main.backgroundColor = Color.red;
	}



	

}
