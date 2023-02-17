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
#if UNITY_EDITOR
        GetInput();
#endif

#if UNITY_ANDROID
        GetMobileInput();
#endif
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

    private void GetMobileInput()
    {
        /*if (Input.touchCount == 1)
        {
            _isTouchPressed = true;
            OnPressed?.Invoke();
        }*/

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Stationary && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                _isTouchPressed = true;
                OnPressed?.Invoke();
            }

            if (_isTouchPressed && touch.phase == TouchPhase.Ended)
            {
                _isTouchPressed = false;

                OnReleased.Invoke();
            }
        }

        
    }
}
