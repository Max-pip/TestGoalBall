using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneLoader : MonoBehaviour
{
    public void RestartScene()
    {
        string currentName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentName);
    }
}
