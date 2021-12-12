using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private float _colorOffset;
    private SpriteRenderer _mySpriteRenderer;
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Bad"))
        {
            _mySpriteRenderer.color = new Color(_mySpriteRenderer.color.r - _colorOffset, _mySpriteRenderer.color.g - _colorOffset, _mySpriteRenderer.color.b - _colorOffset, 255);
        }
        else if(other.CompareTag("Good"))
        {
             _mySpriteRenderer.color = new Color(_mySpriteRenderer.color.r + _colorOffset, _mySpriteRenderer.color.g + _colorOffset, _mySpriteRenderer.color.b + _colorOffset, 255);
        }
    }
}
