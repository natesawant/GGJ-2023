using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	void GatherInput()
    {

    }
	// Update is called once per frame
	void LateUpdate () {
		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

        GatherInput();
	}
}