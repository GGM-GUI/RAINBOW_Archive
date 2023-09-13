using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHPUI : MonoBehaviour
{
    private UIDocument _uiDocument;

    private VisualElement _root;
    private VisualElement _playerHpValue;
    
    private List<VisualElement> _marbles = new List<VisualElement>();
        
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;
        _playerHpValue = _root.Q("Value");
        
        _marbles.Add(_root.Q<VisualElement>("GrayMarble"));
        _marbles.Add(_root.Q<VisualElement>("RedMarble"));
        _marbles.Add(_root.Q<VisualElement>("YellowMarble"));
        _marbles.Add(_root.Q<VisualElement>("GreenMarble"));
        _marbles.Add(_root.Q<VisualElement>("BlueMarble"));
        _marbles.Add(_root.Q<VisualElement>("PurpleMarble"));
    }

    public void HPChange(float value)
    {
        _playerHpValue.style.flexBasis = Length.Percent(value);
    }

    //먹을때 실행해주기 
    public void CollisionMarble(AgentAttackState state)
    {
        switch (state)
        {
            case AgentAttackState.RED:
                    _marbles[(int)state].style.backgroundColor = new StyleColor(new Color(253f / 255f, 42f / 255f, 42f / 255f, 1));
                break;
            case AgentAttackState.YEOLLOW:
                _marbles[(int)state].style.backgroundColor = new StyleColor(new Color(231f / 255f, 201f / 255f, 27f / 255f, 1));
                break;
            case AgentAttackState.GREEN:
                _marbles[(int)state].style.backgroundColor = new StyleColor(new Color(124f / 255f, 231f / 255f, 100f / 255f, 1));
                break;
            case AgentAttackState.BLUE:
                _marbles[(int)state].style.backgroundColor = new StyleColor(new Color(27f / 255f, 90f / 255f, 231f / 255f, 1));
                break;
            case AgentAttackState.PURPLE:
                _marbles[(int)state].style.backgroundColor = new StyleColor(new Color(147f / 255f, 27f / 255f, 231f / 255f, 1));
                break;
        }
    }
}
