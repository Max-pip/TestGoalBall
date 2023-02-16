using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{

    public UnityEvent /*CreateBullet,*/ OnPressed, OnReleased;

    private bool _isTouchPressed;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        /*
        if (Input.GetMouseButtonDown(0))
        {
            CreateBullet?.Invoke();
        }
        */

        if (Input.GetMouseButton(0))
        {
            OnPressed?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnReleased.Invoke();
        }
    }
}
