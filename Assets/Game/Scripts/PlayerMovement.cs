using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] float _walkMoveStopRadius = .2f;

    ThirdPersonCharacter _character;
    CameraRaycaster _cameraRaycaster;
    Vector3 _currentClickTarget;

	// Use this for initialization
	private void Start ()
    {
        _cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        _character = GetComponent<ThirdPersonCharacter>();
        _currentClickTarget = transform.position;

        print(_cameraRaycaster.gameObject.name);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit layer: " + _cameraRaycaster.LayerHit);
            switch (_cameraRaycaster.LayerHit)
            {
                case Layer.Walkable:
                    _currentClickTarget = _cameraRaycaster.Hit.point;
                    break;

                case Layer.Enemy:
                    print("This is an Enemy!");
                    break;

                default:
                    print("UNEXPECTED LAYER FOUND");
                    return;

            }

        }

        var playerToClickPoint = _currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= _walkMoveStopRadius)
        {
            _character.Move(playerToClickPoint, false, false);
        }
        else
        {
            _character.Move(Vector3.zero, false, false);
        }

    }
}
