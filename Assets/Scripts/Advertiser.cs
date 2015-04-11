using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class Advertiser : MonoBehaviour {


//	void OnEnable(){
//		Chartboost.didCacheInterstitial += didCacheInterstitial;
//	}
//
//	void OnDisable(){
//		Chartboost.didCacheInterstitial -= didCacheInterstitial;
//	}

	// Use this for initialization
	void Start () {
		if(Chartboost.hasInterstitial(CBLocation.Default)){
			Chartboost.showInterstitial(CBLocation.Default);
		}
	}
	
//	// Update is called once per frame
//	void didCacheInterstitial (CBLocation  loc) {
//		Chartboost.showInterstitial(loc);
//	}
}
