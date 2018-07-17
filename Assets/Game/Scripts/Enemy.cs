using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float _maxHealthPoints = 100f;

    float _currentHealthPoints = 100f;

    public float _healthAsPercentage
    {
        get
        {
            return _currentHealthPoints / (float)_maxHealthPoints;
        }
    }
}
