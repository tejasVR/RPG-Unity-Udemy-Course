using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform _playerObj;
    public float _cameraFollowSpeed;

	// Use this for initialization
	void Start () {
        _playerObj = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void LateUpdate () {

        transform.position = Vector3.Lerp(transform.position, _playerObj.position, Time.deltaTime * _cameraFollowSpeed);
		
	}
}
