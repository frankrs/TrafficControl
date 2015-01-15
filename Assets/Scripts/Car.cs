using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public bool useWheels = false;


	public float speed;

	public float wheelTorque = 30f;

	public WheelCollider[] wheels;

	public Transform rayShoot;

	public float reactionDist;

	//public float brakingPower;

	public LayerMask stopLayer;

	public AnimationCurve breakingCurve;


	void OnDrawGizmos (){
		Debug.DrawRay(rayShoot.position,rayShoot.forward * reactionDist);
	}

	void Awake(){
		wheels = transform.GetComponentsInChildren<WheelCollider>();
	}

	void FixedUpdate () {
		RaycastHit hitInfo;
		if(Physics.Raycast(rayShoot.position,rayShoot.forward,out hitInfo,reactionDist,stopLayer)){
			foreach(WheelCollider w in wheels){
				w.motorTorque = 0f;
				w.brakeTorque = breakingCurve.Evaluate(transform.InverseTransformDirection(rigidbody.velocity).z);
			}
			return;
		}
		if(useWheels){
			foreach(WheelCollider w in wheels){
				w.motorTorque = wheelTorque;
				w.brakeTorque = 0;
			}
		}
		else{
		rigidbody.AddRelativeForce(Vector3.forward * speed);
		}
	}
}
