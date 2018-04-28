using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeRotator : MonoBehaviour {

	public float amount = 200f;

	

	void Start () {
	
	}
	
	
	void Update () {
			{
			transform.Rotate(transform.up * amount * Time.deltaTime, Space.World);
			}
	}
}
