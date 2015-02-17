using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {

	public GameObject[] cars;
	public float minGenTime;
	public float maxGenTime;
	public LayerMask carLayer;
	public float proxiomity = 1f;

	public delegate void Jam();
	public static event Jam OnJam;

	// Use this for initialization
	void Start () {
		StartCoroutine("BuildCar");
	}

	public IEnumerator BuildCar (){
		yield return new WaitForSeconds(Random.Range(minGenTime,maxGenTime));
		RaycastHit hit;
		if(Physics.SphereCast((new Vector3(transform.position.x,transform.position.y + 10f,transform.position.z)),proxiomity,-transform.up, out hit,15f, carLayer)){
			OnJam();
			StartCoroutine("BuildCar");
		}
		else{
			GameObject car = GameObject.Instantiate(cars[Random.Range(0,cars.Length)],transform.position,transform.rotation) as GameObject;
			StartCoroutine("BuildCar");
		}
	}

}
