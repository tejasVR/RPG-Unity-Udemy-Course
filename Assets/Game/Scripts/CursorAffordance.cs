using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    CameraRaycaster _cameraRaycaster;


    [SerializeField] Texture2D _walkCursor;
    [SerializeField] Texture2D _targetCursor;
    [SerializeField] Texture2D _unknownCursor;

    Vector2 hotSpot = new Vector2(96, 96);

	// Use this for initialization
	void Start () {
        _cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (_cameraRaycaster.LayerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(_walkCursor, hotSpot, CursorMode.Auto);
                break;

            case Layer.Enemy:
                Cursor.SetCursor(_targetCursor, hotSpot, CursorMode.Auto);
                break;

            case Layer.RaycastEndStop:
                Cursor.SetCursor(_unknownCursor, hotSpot, CursorMode.Auto);
                break;

            default:
                Debug.Log("Don't know which cursor to show!");
                return;
        }

        //print(_cameraRaycaster.LayerHit);
	}
}
