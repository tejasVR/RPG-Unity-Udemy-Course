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

    public delegate void OnLayerChange(Layer newLayer); // declare new delegate type
    public event OnLayerChange _layerChangeObservers; // instantiate an observer set

    //void LayerChangeHandler()
    //{
    //    print("layerHandler");
    //}

    // Use this for initialization
    void Start () {
        _viewCamera = Camera.main;
        //_layerChangeObservers += LayerChangeHandler; // add to set of handling functions
        //_layerChangeObservers(); // call the delegates
	}

	// Update is called once per frame
	void Update () {

        foreach (var layer in layerProperties)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                _hit = hit.Value;
                if (LayerHit != layer)
                {
                    _layerHit = layer;
                    _layerChangeObservers(layer); // call delegate
                }
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
