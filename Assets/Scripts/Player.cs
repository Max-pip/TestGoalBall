using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private GameObject _currentPrefab;
    private float _prefabSpeed = 0f;

    private void Update()
    {
        if (_currentPrefab != null)
        {
            _currentPrefab.transform.position += Vector3.forward * _prefabSpeed * Time.deltaTime;
        }
    }

    public void PlayerLocalScale()
    {
        transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);
        if (_currentPrefab == null)
        {
            _currentPrefab = (GameObject) Instantiate(_prefab, new Vector3(0, 1, -11), transform.rotation);
        }

        if (_currentPrefab != null )
        {
            _currentPrefab.transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);
        }
    }

    public void ButtonUp()
    {
        _prefabSpeed = 10f;
        Debug.Log("Up!");
    }
}
