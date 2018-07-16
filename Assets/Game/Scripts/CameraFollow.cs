using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform _playerObj;
    public float _cameraFollowSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	void LateUpdate () {

        transform.position = Vector3.Lerp(transform.position, _playerObj.transform.position, Time.deltaTime * _cameraFollowSpeed);
		
	}
}
