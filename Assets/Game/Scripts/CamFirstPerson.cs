using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFirstPerson : MonoBehaviour {

    GameObject _player;

    Vector2 _mouseLook;
    Vector2 _smoothV;

    public float _mouseSensitivity = 5.0f;
    public float _mouseSmoothing = 2.0f;

    //Transform _target;
    PlayerUserControl _userControl;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, -90, 90);

        float rotAmountX = mouseX * _mouseSensitivity;
        float rotAmountY = mouseY * _mouseSensitivity;

        Vector2 targetRot = transform.rotation.eulerAngles;

        targetRot.x -= rotAmountY;
        targetRot.y += rotAmountX;
        //targetRot.z = 0;

        transform.rotation = Quaternion.Euler(targetRot);

        //var mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //mouseDir = Vector2.Scale(mouseDir, new Vector2(_mouseSensitivity * _mouseSmoothing, _mouseSensitivity * _mouseSmoothing));
        //_smoothV.x = Mathf.Lerp(_smoothV.x, mouseDir.x, 1f / _mouseSmoothing);
        //_smoothV.y = Mathf.Lerp(_smoothV.y, mouseDir.y, 1f / _mouseSmoothing);
        //_mouseLook += _smoothV;

        //transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        //_player.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _player.transform.up);

    }
}
