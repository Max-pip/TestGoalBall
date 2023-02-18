using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ToDestroyColor()
    {
        _renderer.material.SetColor("_Color", Color.yellow);
    }

    public void TestSomething()
    {
        Debug.Log("Yes");
    }
    
}
