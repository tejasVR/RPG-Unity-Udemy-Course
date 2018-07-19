using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform _target;
    public float _cameraFollowSpeed;

	// Use this for initialization
	void Start () {
        //_target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void LateUpdate () {

        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _cameraFollowSpeed);
		
	}
}
