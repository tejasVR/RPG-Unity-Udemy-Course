using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    public enum MovementMode
    {
        MouseMove,
        KeyboardMove,
        GampadMove
    }

    public MovementMode _movementMode;

    [SerializeField] float _walkStopMoveRadius = .2f;
    [SerializeField] float _attackStopMoveRadius = .1f;

    ThirdPersonCharacter _character;
    CameraRaycaster _cameraRaycaster;
    Vector3 _currentClickTarget;

    public bool _isDirectMovement = true;

	// Use this for initialization
	private void Start ()
    {
        _cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        _character = GetComponent<ThirdPersonCharacter>();
        _currentClickTarget = transform.position;

        //print(_cameraRaycaster.gameObject.name);
	}

    // Fix mouse click and WASD coflicting movement

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _isDirectMovement = !_isDirectMovement; //toggle mouse/keybpard movement
            _currentClickTarget = transform.position; // clear click target
        }
    }

    void FixedUpdate ()
    {
        if (_isDirectMovement)
            ProcessMouseMovement();
        else
            ProcessKeyboardMovement();
    }

    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {
            //print("Cursor raycast hit layer: " + _cameraRaycaster.LayerHit);
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

        PlayerToDestination();
    }

    private void PlayerToDestination()
    {
        var playerToClickPoint = _currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= _walkStopMoveRadius)
        {
            _character.Move(playerToClickPoint, false, false);
        }
        else
        {
            _character.Move(Vector3.zero, false, false);
        }
    }

    private void ProcessKeyboardMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        bool crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        //if (Camera.main != null)
        
            // calculate camera relative direction to move:
            Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3  move = v * camForward + h * Camera.main.transform.right;
        
        _character.Move(move, crouch, false);
    }

    private void OnDrawGizmos()
    {
        // Draw movement gizmos
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, _currentClickTarget);
        Gizmos.DrawSphere(_currentClickTarget, _walkStopMoveRadius);
    }

}
