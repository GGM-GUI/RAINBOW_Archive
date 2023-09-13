using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInput : MonoBehaviour
{
    public static AgentInput Instance;
    
    public Action<Vector2> OnMovementKeyPress = null;
    public Action OnAttackKeyPress = null;
    public Action<Vector2> OnDashKeyPress = null;
    public Action OnPaletteKeyPress = null;
    public Action OnInteractionKeyPress = null;
    
    private Vector2 _movePos;
    private AgentAttack _agentAttack;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple AgentInput running");
        else
            Instance = this;
    }

    private void Start()
    {
        _agentAttack = GameObject.Find("PlayerAttack").GetComponent<AgentAttack>();
    }

    private void Update()
    {
        UpdateMoveInput();
        UpdateAttackInput();
        UpdateDashInput();
        UpdatePaletteInput();
        UpdateInteractionInput();
    }

    private void UpdateMoveInput()
    {
        if (_agentAttack.IsAttack)
            _movePos = Vector2.zero;
        else if (Input.GetKey(KeyManager.Instance.UpKey))   
            _movePos = Vector2.up;
        else if (Input.GetKey(KeyManager.Instance.LeftKey))
            _movePos = Vector2.left;
        else if (Input.GetKey(KeyManager.Instance.DownKey))
            _movePos = Vector2.down;
        else if (Input.GetKey(KeyManager.Instance.RightKey))
            _movePos = Vector2.right;
        else
            _movePos = Vector2.zero;
        
        OnMovementKeyPress?.Invoke(_movePos);
    }

    private void UpdateAttackInput()
    {
        if (Input.GetKeyDown(KeyManager.Instance.AttackKey))
            OnAttackKeyPress?.Invoke();
    }

    private void UpdateDashInput()
    {
        if (Input.GetKeyDown(KeyManager.Instance.DashKey))
            OnDashKeyPress?.Invoke(_movePos);
    }

    private void UpdatePaletteInput()
    {
        if (Input.GetKeyDown(KeyManager.Instance.PaletteKey))
            OnPaletteKeyPress?.Invoke();
    }

    private void UpdateInteractionInput()
    {
        if (Input.GetKeyDown(KeyManager.Instance.InteractionKey))
            OnInteractionKeyPress?.Invoke();
    }
}
