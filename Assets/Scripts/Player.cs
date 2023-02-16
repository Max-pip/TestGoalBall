using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void PlayerLocalScale()
    {
        transform.localScale -= new Vector3(0.002f, 0.002f, 0.002f);
    }

    public void ButtonUp()
    {
        Debug.Log("Up!");
    }
}
