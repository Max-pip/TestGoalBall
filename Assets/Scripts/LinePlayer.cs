using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    void Update()
    {
        transform.localScale = new Vector3(_player.transform.localScale.x, 0.01f, 24.5f);
    }
}
