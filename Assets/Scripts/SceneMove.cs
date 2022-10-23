using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;

public class SceneMove : MonoBehaviour
{
    public void OnTriggerEnter2D()
    {
        MMSceneLoadingManager.LoadScene("Arkos");
    }
}
