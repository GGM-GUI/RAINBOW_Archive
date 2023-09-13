using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaletteUI : MonoBehaviour, IAgentComponent
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    private VisualElement _palette;
    private bool _isPalette = false;

    private List<Button> _btns = new List<Button>();

    private void OnEnable()
    {
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;
        
        _btns.Add(_root.Q<Button>("GrayButton"));
        _btns.Add(_root.Q<Button>("RedButton"));
        _btns.Add(_root.Q<Button>("YellowButton"));
        _btns.Add(_root.Q<Button>("GreenButton"));
        _btns.Add(_root.Q<Button>("BlueButton"));
        _btns.Add(_root.Q<Button>("PurpleButton"));
        
        _palette = _root.Q<VisualElement>("Palette");
        
        _btns[0].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.GRAY );
        _btns[1].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.RED );
        _btns[2].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.YEOLLOW );
        _btns[3].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.GREEN );
        _btns[4].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.BLUE );
        _btns[5].RegisterCallback<ClickEvent>(evt => AgentController.Instance.AttackState = AgentAttackState.PURPLE );
    }

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.RUNNING:
            case GameState.STANDBY:
                Init();
                break;
            default:
                UnInit();
                break;
        }
    }

    public void Init()
    {
        if (AgentInput.Instance.OnPaletteKeyPress == null)
        {
            AgentInput.Instance.OnPaletteKeyPress += Palette;
        }
    }

    public void UnInit()
    {
        AgentInput.Instance.OnPaletteKeyPress -= Palette;
    }

    private void Palette()
    {
        _isPalette = !_isPalette;
        
        if (_isPalette)
        {
            _palette.AddToClassList("on");
            GameManager.Instance.UpdateState(GameState.STANDBY);
        }
        else
        {
            _palette.RemoveFromClassList("on");
            GameManager.Instance.UpdateState(GameState.RUNNING);
        }
    }

    //먹을때 실행해주기 
    public void CollisionMarble(AgentAttackState state)
    {
        _btns[(int)state].AddToClassList("show");
    }
}
