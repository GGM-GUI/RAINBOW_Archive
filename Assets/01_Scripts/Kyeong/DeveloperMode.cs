using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            transform.position = new Vector3(18.2f, 49.4f, 0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            transform.position = new Vector3(-92.5f, -16.8f, 0);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            transform.position = new Vector3(-10.7f, -8.4f, 0);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            transform.position = new Vector3(145.9f, -14.8f, 0);
    }
}
