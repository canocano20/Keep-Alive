using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBackground : MonoBehaviour
{
    [SerializeField] private Gradient _backgroundGradient;
    [SerializeField] private float _colorTimeSpeed;

    private SpriteRenderer _mySpriteRenderer;
    private float _colorTime;

    void Start()
    {
       _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        _colorTime = Mathf.PingPong(Time.time * _colorTimeSpeed, 1);
        _mySpriteRenderer.color = _backgroundGradient.Evaluate(_colorTime);
    }
}
