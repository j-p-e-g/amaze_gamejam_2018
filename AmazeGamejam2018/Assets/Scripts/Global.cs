using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
	public bool hideObjectsAtStart = true;
	public bool showObjectsAtEnd = true;
	
	private GameObject[] shadowObjects;
	
	void Start ()
    {
		shadowObjects = GameObject.FindGameObjectsWithTag("ShadowsOnly");
		if (hideObjectsAtStart)
		{
			this.SetShadowCastingModeForObjects(shadowObjects, UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly);
		}
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
			if (showObjectsAtEnd)
			{
				this.SetShadowCastingModeForObjects(shadowObjects, UnityEngine.Rendering.ShadowCastingMode.On);
			}
		}
    }

	private void SetShadowCastingModeForObjects(GameObject[] objects, UnityEngine.Rendering.ShadowCastingMode mode)
	{
		foreach (GameObject obj in objects)
		{
			MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
            if (mesh)
            {
                mesh.shadowCastingMode = mode;
            }
		}
	}
	
}
