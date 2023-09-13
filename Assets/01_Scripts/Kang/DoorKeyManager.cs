using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyManager : MonoBehaviour
{
    public static DoorKeyManager Instance;
    [HideInInspector] public int getKeyNum = 1;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
