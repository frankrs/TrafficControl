using UnityEngine;
using System.Collections;
using Facebook;

public class ScorePost : MonoBehaviour {
	public string gameUrl;
	public string gameIconUrl;


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
		string mes ;
		mes =  "I Sored " + Stats.Goals.ToString() + " in City Stoplight Simulator level "  + ((Application.loadedLevel)-1).ToString();
		FB.Feed(link: gameUrl,picture: gameIconUrl, linkName: mes );
	}
}
