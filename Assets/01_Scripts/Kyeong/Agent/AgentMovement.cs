using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AgentMovement : MonoBehaviour, IAgentComponent
{
    [Header("Move")]
    [SerializeField] private float _speed;
    
    [Header("Dash")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _travelTime;
    [SerializeField] private float _coolTime;
    private float _currentTime;
    
    private Transform _playerTrm;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerTrm = GameManager.Instance.Player.transform;
        _currentTime = _coolTime;
    }

    private void Update()
    {
        _currentTime -= Time.unscaledDeltaTime; // Time.TimeScale ���� ������� �۵�
    }

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.RUNNING:
                Init();
                break;
            default:
                UnInit();
                break;
        }
    }

    public void Init()
    {
        AgentInput.Instance.OnMovementKeyPress += Movement;
        AgentInput.Instance.OnDashKeyPress += Dash;
    }

    public void UnInit()
    {
        AgentInput.Instance.OnMovementKeyPress -= Movement;
        AgentInput.Instance.OnDashKeyPress -= Dash;
        _rigidbody2D.velocity = Vector3.zero;
        
    }

    private void Movement(Vector2 pos)
    {
        _rigidbody2D.velocity = pos * _speed;
    }

    private void Dash(Vector2 pos)
    {
        if (pos == Vector2.zero || _currentTime >= 0)
            return;
        
        Vector2 movePos = _playerTrm.position + (Vector3)(pos * _dashSpeed);
        _playerTrm.DOMove(movePos, _travelTime, false).SetEase(Ease.Linear);
        _currentTime = _coolTime;
    }
}
