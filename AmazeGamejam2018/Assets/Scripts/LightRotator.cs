using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotator : MonoBehaviour {

	public float speed = 200f;
	public GameObject HeadAxis;
	private Rigidbody myRigidbody;
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	
	void Update () {
		Debug.Log("Update");
		float h = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		myRigidbody.AddTorque(transform.right * h);

	
	}
}
