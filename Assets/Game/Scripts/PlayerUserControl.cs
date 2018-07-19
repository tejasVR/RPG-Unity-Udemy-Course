using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent (typeof (PlayerMovement))]
public class PlayerUserControl : MonoBehaviour
{
    private PlayerMovement m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    public bool _crouch;
    public bool _useWeapon;

    [SerializeField] GameObject _playerBody;
    [SerializeField] GameObject _weapon;


    private void Start()
    {
      
    }


    private void Update()
    {
       

        if (Input.GetMouseButtonDown(1))
        {
            ShowWeapon();
            _useWeapon = !_useWeapon;
            //transform.rotation = Camera.main
        }

        if (Input.GetMouseButtonUp(1))
        {
            HideWeapon();
            _useWeapon = !_useWeapon;
        }
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
       
    }

    private void ShowWeapon()
    {
        _playerBody.SetActive(false);
        _weapon.SetActive(true);
    }

    private void HideWeapon()
    {
        _playerBody.SetActive(true);
        _weapon.SetActive(false);
    }
}
