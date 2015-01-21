using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {


	public delegate void Crash();
	public static event Crash OnCrash;

	
	public float speedLimit;

//	public float wheelTorque = 10f;
	public AnimationCurve transmission;
	private float gasTime = 0f;

	private WheelCollider[] wheels;

	public Transform rayShoot;

	public float reactionDist;

	//public float brakingPower;

	public LayerMask stopLayer;



	public float startSpeed;

	public AudioClip[] crashSounds;

	public bool crashed = false;


	public AnimationCurve brakePerDistance;


	void OnDrawGizmos (){
		Debug.DrawRay(rayShoot.position,rayShoot.forward * reactionDist);
	}

	void Awake(){
		wheels = transform.GetComponentsInChildren<WheelCollider>();
	}

	void Start (){
		rigidbody.velocity = (transform.forward * startSpeed);
	}

	void FixedUpdate () {
		if(crashed){
			return;
		}
		RaycastHit hitInfo;
		if(Physics.Raycast(rayShoot.position,rayShoot.forward,out hitInfo,reactionDist,stopLayer)){
			foreach(WheelCollider w in wheels){
				w.motorTorque = 0f;
				gasTime = 0f;

				w.brakeTorque = brakePerDistance.Evaluate(hitInfo.distance);

			}
			return;
		}
		if(rigidbody.velocity.magnitude < speedLimit){
			gasTime = gasTime + Time.deltaTime;
			foreach(WheelCollider w in wheels){
//				w.motorTorque = wheelTorque;
				w.brakeTorque = 0;
				w.motorTorque = transmission.Evaluate(gasTime);
			}
		}
//		if(transform.InverseTransformDirection(rigidbody.velocity).z > speedLimit){
//			rigidbody.velocity = rigidbody.velocity.normalized * speedLimit;
//		}

	}


	void OnCollisionEnter(Collision col){
		if(crashed){
			return;
		}
		if(col.collider.tag == "Car"){
			crashed = true;
			OnCrash();
			audio.PlayOneShot(crashSounds[Random.Range(0,crashSounds.Length)]);
		}
	}



	void OnGoal(){
		Destroy(gameObject);
	}



}


[System.Serializable]
public enum BrakeMethod {
	Distance,Speed
}

