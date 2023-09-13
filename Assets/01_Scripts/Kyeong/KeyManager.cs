using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance = null;
    
    [HideInInspector] public KeyCode UpKey, LeftKey, RightKey, DownKey;
    [HideInInspector] public KeyCode AttackKey;
    [HideInInspector] public KeyCode DashKey;
    [HideInInspector] public KeyCode PaletteKey;
    [HideInInspector] public KeyCode InteractionKey;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple KeyManager is running");
        else
            Instance = this;
    }

    private void Start() // ????????? ?????¡Æ?, ????? ???? ????. 
    {
        if (UpKey == KeyCode.None)
            UpKey = KeyCode.W;
        if (LeftKey == KeyCode.None)
            LeftKey = KeyCode.A;
        if (RightKey == KeyCode.None)
            RightKey = KeyCode.D;
        if (DownKey == KeyCode.None)
            DownKey = KeyCode.S;

        if (AttackKey == KeyCode.None)
            AttackKey = KeyCode.K;
        if (DashKey == KeyCode.None)
            DashKey = KeyCode.LeftShift;
        if (PaletteKey == KeyCode.None)
            PaletteKey = KeyCode.P;
        if (InteractionKey == KeyCode.None)
            InteractionKey = KeyCode.Space;
    }
}
