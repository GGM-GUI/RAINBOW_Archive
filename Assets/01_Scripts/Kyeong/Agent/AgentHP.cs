using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHP : MonoBehaviour, IAgentComponent
{
    [SerializeField] private float _playerHP;
    private float _currentHP;
    public float CurrentHP
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP = value;
            if (_currentHP <= 0)
            {
                Debug.Log("Player Dead");
                _currentHP = 0;
            }
            _playerHp.HPChange((_currentHP / _playerHP) * 100f);
        }
    }

    private bool _isPlaying = false;
    private PlayerHPUI _playerHp;
    
    private void Awake()
    {
        _playerHp = transform.GetChild(6).GetComponent<PlayerHPUI>();
        CurrentHP = _playerHP;
    }

    #region Interface

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
        _isPlaying = true;
    }

    public void UnInit()
    {
        _isPlaying = false;
    }
    
    #endregion

    public void AgentAttacked(int damage)
    {
        CurrentHP -= damage;
        print(CurrentHP);
        // 대충 이거 사용할때
        // collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(damage);
        // 이런식으로 사용
    }
}
