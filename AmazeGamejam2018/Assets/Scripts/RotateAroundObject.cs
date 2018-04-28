using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
	public GameObject centerObject;
    public float speed = 100;
    public float initialTimeOffset = 15;

    private Transform initialTransform;

	void Start ()
    {
        initialTransform = this.transform;
        this.transform.LookAt(centerObject.transform);
        this.DoRotate(initialTimeOffset);
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        HandlePlayerInput(Time.deltaTime);
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
		Debug.Log("HandleArrowClick dir: " + dir);
		this.DoRotate(dir * speed);
    }

    private void DoRotate(float speed)
    {
        transform.RotateAround(centerObject.transform.position, Vector3.up, speed);
    }

    void ResetTransform()
    {
        this.transform.position = initialTransform.position;
        this.transform.rotation = initialTransform.rotation;
    }
}
