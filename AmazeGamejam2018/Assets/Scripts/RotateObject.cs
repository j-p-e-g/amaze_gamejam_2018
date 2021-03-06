﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 100;

    private Transform initialTransform;
	private int rotationDir = 0;

	void Start ()
    {
        // initialTransform = this.transform;
        // this.transform.LookAt(centerObject.transform);
        // this.DoRotate(initialTimeOffset);
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        HandlePlayerInput(Time.deltaTime);
		
		if (rotationDir != 0)
		{
			this.DoRotate(rotationDir * speed);
		}
    }

    private void HandlePlayerInput(float time)
    {
        if (Input.GetAxis("Submit") == 1)
        {
            this.ResetTransform();
        }
        else
        {
            float translation = Input.GetAxis("Horizontal") * speed;
            this.DoRotate(translation);
        }
    }

    public void HandleArrowClick(int dir)
    {
		// Debug.Log("HandleArrowClick dir: " + dir);
		// this.DoRotate(dir * speed);
    }

    public void OnStartRotating(int dir)
    {
		rotationDir = dir;
    }

    public void OnStopRotating()
    {
		rotationDir = 0;
    }

    private void DoRotate(float speed)
    {
		transform.Rotate(Vector3.up * speed);
		// transform.rotation = new Quaternion(1,0, 0,1);
		// transform.eulerAngles += Vector3.right * speed;
        // transform.RotateAround(centerObject.transform.position, Vector3.up, speed);
    }

    void ResetTransform()
    {
        // this.transform.position = initialTransform.position;
        // this.transform.rotation = initialTransform.rotation;
    }
}
