using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour {

    public Layer[] layerProperties =
    {
        Layer.Enemy,
        Layer.Walkable
    };


    [SerializeField] float _distanceToBackground = 100f;
    Camera _viewCamera;

    RaycastHit _hit;
    public RaycastHit Hit
    {
        get { return _hit; }
    }

    Layer _layerHit;
    public Layer LayerHit
    {
        get { return _layerHit; }
    }

	// Use this for initialization
	void Start () {
        _viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        foreach (var layer in layerProperties)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                _hit = hit.Value;
                _layerHit = layer;
                return;
            }
        }

        _hit.distance = _distanceToBackground;
        _layerHit = Layer.RaycastEndStop;
	}

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer;
        Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit, _distanceToBackground, layerMask);

        if (hasHit)
        {
            return hit;
        }

        return null;

    }
}
