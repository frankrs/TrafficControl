using UnityEngine;
using System.Collections;

public class HZ_Test : MonoBehaviour {

	public string userId;


	public void InitializeSDK () {
		HeyzapAds.start("a9e8962ed594787fd6f4a3c1e5dc7223", HeyzapAds.FLAG_NO_OPTIONS);
	}


	public void Med () {
		HeyzapAds.showMediationTestSuite();
	}

}
