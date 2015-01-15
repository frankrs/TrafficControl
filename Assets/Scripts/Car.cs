using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public bool useWheels = false;


	public float speed;

	public float wheelTorque = 30f;

	public WheelCollider[] wheels;

	void Awake(){
		wheels = transform.GetComponentsInChildren<WheelCollider>();
	}

	void FixedUpdate () {
		if(useWheels){
			foreach(WheelCollider w in wheels){
				w.motorTorque = wheelTorque;
			}
		}
		else{
		rigidbody.AddRelativeForce(Vector3.forward * speed);
		}
	}
}
