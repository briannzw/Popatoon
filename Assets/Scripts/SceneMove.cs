using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;

public class SceneMove : MonoBehaviour
{
    public string sceneName;

    public void OnTriggerEnter2D()
    {
        LoadScene(sceneName);
    }

    public void LoadScene(string _sceneName)
    {
        MMSceneLoadingManager.LoadScene(_sceneName);
    }
}
