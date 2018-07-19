using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] Transform _firstPersonViewAngle;
    [SerializeField] Transform _crouchViewAngle;
    [SerializeField] Transform _standViewAngle;

    PlayerUserControl _userControl;

    private void Start()
    {
        _userControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUserControl>();
    }
}
