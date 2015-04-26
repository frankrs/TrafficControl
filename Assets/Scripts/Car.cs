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

	private Quaternion startRot;


	void OnDrawGizmos (){
		Debug.DrawRay(rayShoot.position,rayShoot.forward * reactionDist);
	}

	void Awake(){
		wheels = transform.GetComponentsInChildren<WheelCollider>();
	}

	void Start (){
		rigidbody.velocity = (transform.forward * startSpeed);
		startRot = transform.rotation;
	}

	void FixedUpdate () {
		if(crashed){
			return;
		}

		rigidbody.rotation = startRot;

		RaycastHit hitInfo;
		if(Physics.Raycast(rayShoot.position,rayShoot.forward,out hitInfo,reactionDist,stopLayer)){
			gasTime = 0f;
			foreach(WheelCollider w in wheels){
				w.motorTorque = 0f;
				w.brakeTorque = brakePerDistance.Evaluate(hitInfo.distance);
			}
			return;
		}
		if(rigidbody.velocity.magnitude < speedLimit){
			gasTime = gasTime + Time.fixedDeltaTime;
			foreach(WheelCollider w in wheels){
				w.brakeTorque = 0;
				w.motorTorque = transmission.Evaluate(gasTime);
			}
		}
//		if(transform.InverseTransformDirection(rigidbody.velocity).z > speedLimit){
//			rigidbody.velocity = rigidbody.velocity.normalized * speedLimit;
//		}

	}


	void OnCollisionEnter(Collision col){
//		Debug.Log (col);
		if(crashed){ 
			return;
		}
		if(col.gameObject.tag == "Car"){
			crashed = 		true;
			OnCrash();
			audio.PlayOneShot(crashSounds[Random.Range(0,crashSounds.Length)],1f);
			foreach(WheelCollider w in wheels){
				w.motorTorque = 0f;
				w.brakeTorque = 50f;
			}
		}
	}

//	void OnCollisionStay(Collision col){
//		//		Debug.Log (col);
//		if(crashed){ 
//			return;
//		}
//		if(col.collider.tag == "Car"){
//			crashed = 		true;
//			OnCrash();
//			audio.PlayOneShot(crashSounds[Random.Range(0,crashSounds.Length)],1f);
//			foreach(WheelCollider w in wheels){
//				w.motorTorque = 0f;
//				w.brakeTorque = 50f;
//			}
//		}
//	}

	void OnGoal(){
		Destroy(gameObject);
	}


	void OnWrecker (AudioClip[] a){
		if(crashed){
			AudioSource.PlayClipAtPoint(a[0],new Vector3(0,0,0));
			Destroy(gameObject);
		}
		else{
			audio.PlayOneShot(a[1]);
		}
	}


}


[System.Serializable]
public enum BrakeMethod {
	Distance,Speed
}

