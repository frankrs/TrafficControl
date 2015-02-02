using UnityEngine;
using System.Collections;

public class Randomtimer : MonoBehaviour {
	public float mintime = 5;
	public float maxtime = 21;
	float time;


	void Start (){
		time = Random.Range (mintime, maxtime);
	}
}