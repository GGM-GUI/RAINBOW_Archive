using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimator : MonoBehaviour, IAgentComponent
{
    private readonly int _posXHash = Animator.StringToHash("PosX");
    private readonly int _posYHash = Animator.StringToHash("PosY");

    private Animator _animator;
    private Vector2 _pos;
    private bool _isStop = false;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
        AgentInput.Instance.OnMovementKeyPress += MoveAnimation;
    }

    public void UnInit()
    {
        AgentInput.Instance.OnMovementKeyPress -= MoveAnimation;
    }

    private void MoveAnimation(Vector2 pos)
    {
        if (pos != Vector2.zero)
            _pos = pos;
        else 
            AnimationStop(_pos);
        
        _animator.SetFloat(_posXHash, _pos.x);
        _animator.SetFloat(_posYHash, _pos.y);
    }

    private void AnimationStop(Vector2 pos)
    {
        if (!_isStop)
            _isStop = !_isStop;

        if (pos == Vector2.up)
            _pos = new Vector2(-1, 1);
        else if (pos == Vector2.left)
            _pos = new Vector2(-1, -1);
        else if (pos == Vector2.right)
            _pos = new Vector2(1, 1);
        else if (pos == Vector2.down)
            _pos = new Vector2(1, -1);
    }
}
