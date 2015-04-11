using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class AdCacher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Chartboost.cacheInterstitial(CBLocation.Default);
	}
	

}
