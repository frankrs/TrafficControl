using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {


	public float speed;

	void FixedUpdate () {
		rigidbody.AddRelativeForce(Vector3.forward * speed);
	}
}
