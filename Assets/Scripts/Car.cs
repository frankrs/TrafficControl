﻿using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {


	public delegate void Crash();
	public static event Crash OnCrash;

	
	public float speedLimit;

	public float wheelTorque = 30f;

	private WheelCollider[] wheels;

	public Transform rayShoot;

	public float reactionDist;

	//public float brakingPower;

	public LayerMask stopLayer;

	public AnimationCurve breakingCurve;

	public float startSpeed;

	public AudioClip[] crashSounds;

	public bool crashed = false;


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
				w.brakeTorque = breakingCurve.Evaluate(transform.InverseTransformDirection(rigidbody.velocity).z);
			}
			return;
		}
		if(rigidbody.velocity.magnitude < speedLimit){
			foreach(WheelCollider w in wheels){
				w.motorTorque = wheelTorque;
				w.brakeTorque = 0;
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



}
