using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour {

    [SerializeField] GameObject _playerBody;
    [SerializeField] GameObject _weapon;

    public static bool _usingWeapon;


	// Use this for initialization
	void Start () {
        _weapon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            ShowWeapon();
        }

        if (Input.GetMouseButtonUp(1))
        {
            HideWeapon();
        }
		
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
