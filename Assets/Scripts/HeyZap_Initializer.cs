using UnityEngine;
using System.Collections;

public class HeyZap_Initializer : MonoBehaviour {

	public string heyZapPubID;

	void Start () {
		HeyzapAds.start(heyZapPubID, HeyzapAds.FLAG_NO_OPTIONS);
	}

}
