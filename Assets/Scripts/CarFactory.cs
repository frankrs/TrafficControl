using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {

	public GameObject[] cars;
	public float minGenTime;
	public float maxGenTime;

	// Use this for initialization
	void Start () {
		StartCoroutine("BuildCar");
	}

	public IEnumerator BuildCar (){
		yield return new WaitForSeconds(Random.Range(minGenTime,maxGenTime));
		GameObject car = GameObject.Instantiate(cars[0],transform.position,transform.rotation) as GameObject;
		StartCoroutine("BuildCar");
	}

}
