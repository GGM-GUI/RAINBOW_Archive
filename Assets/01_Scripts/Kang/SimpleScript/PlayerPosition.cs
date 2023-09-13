using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition Instance;
    public Transform player;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
