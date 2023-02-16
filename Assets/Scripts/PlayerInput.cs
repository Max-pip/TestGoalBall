using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{

    public UnityEvent OnPressed, OnReleased;

    private bool _isTouchPressed;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

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
