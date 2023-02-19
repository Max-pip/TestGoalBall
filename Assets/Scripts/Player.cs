using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    [Header("Player`s setting")]
    [SerializeField] private GameObject _prefab;
    private GameObject _currentPrefab;
    private float _prefabSpeed = 0f;
    private bool _canChangeSize;
    private bool _isLose = false;

    private void Update()
    {
        if (_currentPrefab != null)
        {
            _currentPrefab.transform.position += Vector3.forward * _prefabSpeed * Time.deltaTime;
        }
        if (_currentPrefab == null )
        {
            _prefabSpeed = 0f;
            _canChangeSize = true;
        }

        if (transform.localScale.x < 0.3f)
        {
            _isLose = true;
            _canChangeSize = false;
            _losePanel.SetActive(true);
        }
    }

    public void PlayerLocalScale()
    {
        if (!_isLose)
        {
            if (_canChangeSize)
            {
                transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);
            }
            if (_currentPrefab == null)
            {
                _currentPrefab = (GameObject)Instantiate(_prefab, new Vector3(0, 1, -10), transform.rotation);
            }

            if (_currentPrefab != null && _canChangeSize)
            {
                _currentPrefab.transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);
            }
        }       
    }

    public void ButtonUp()
    {
        _canChangeSize = false;
        SetSpeedBullet(10);
    }

    public void SetSpeedBullet(float speed)
    {
        _prefabSpeed = speed;
    }
}
