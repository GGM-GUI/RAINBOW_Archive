using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameState state;
    public GameObject Player;
    private List<IComponent> components = new List<IComponent>();

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GameManager running");
        else
            Instance = this;

        Player = GameObject.Find("Player").gameObject;
    }

    private void Start()
    {
        state = GameState.INIT;
        components.Add(FindObjectOfType<AgentController>());
        UpdateState(state);
    }

    public void UpdateState(GameState state)
    {
        this.state = state;

        foreach (IComponent component in components)
            component.UpdateState(state);
        
        if(state == GameState.INIT)
            UpdateState(GameState.RUNNING);
    }
}
