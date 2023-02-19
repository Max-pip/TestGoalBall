using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ToDestroyColor()
    {
        _renderer.material.SetColor("_Color", Color.yellow);
    }

    public void DestroyEffect()
    {
        GameObject destroyEffect = (GameObject)Instantiate(_destroyEffect, transform.position, transform.rotation);
        Destroy(destroyEffect, 2f);
    }    
}
