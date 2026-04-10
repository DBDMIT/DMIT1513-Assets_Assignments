using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class screen_switch : MonoBehaviour
{
    public UnityEvent OnCamera;
    public List<GameObject> cameras = new List<GameObject>();
    public GameObject blackCamera;
    public int activeCamera;

    public void Switch()
    {
        activeCamera = activeCamera + 1;
        
        if(activeCamera > cameras.Count - 1)
        {
            activeCamera = 0;
        }
        if(activeCamera > 0)
        {
            cameras[activeCamera - 1].SetActive(false);
        }
        if(activeCamera == 0)
        {
            cameras[cameras.Count - 1].SetActive(false);
        }
        cameras[activeCamera].SetActive(true);
    }

    private void Update()
    {
        if (activeCamera == cameras.Count - 1)
        {
            OnCamera?.Invoke();
        }
    }
}
