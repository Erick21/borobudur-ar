using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonHoldCustomHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float _holdTime = 2f;
    [SerializeField] UnityEvent _onClick;

    float _mouseDownStart;
    bool _isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        _mouseDownStart = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    void LateUpdate() 
    {
        if (_isPressed && _onClick != null && (Time.time - _mouseDownStart) >= _holdTime)
        {
            _onClick.Invoke();
            _isPressed = false;
        }
    }
}
