using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AgentController : MonoBehaviour, IComponent
{
    public static AgentController Instance;
    public AgentAttackState AttackState;

    public Transform PlayerTrm { get; private set; }
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
        
    private List<IAgentComponent> _agentComponents = new List<IAgentComponent>();

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple AgentController is running");
        else
            Instance = this;
        PlayerTrm = transform;
    }

    private void Start()
    {
        _collider = transform.Find("Collision").GetComponent<Collider2D>();
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        AttackState = AgentAttackState.GRAY;
        Invincible();
    }

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();
                break;
        }

        foreach (IAgentComponent agentComponent in _agentComponents)
            agentComponent.UpdateState(state);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void Init()
    {
        _agentComponents.Add(FindObjectOfType<AgentMovement>());
        _agentComponents.Add(FindObjectOfType<AgentAnimator>());
        _agentComponents.Add(FindObjectOfType<InteractionTrigger>());
        _agentComponents.Add(FindObjectOfType<AgentAttack>());
        _agentComponents.Add(FindObjectOfType<PaletteUI>());
    }

    // 플레이어 피격시에 실행, 무적상태로 변함 
    public void Invincible(float time = 0.7f)
    {
        StopAllCoroutines();
        StartCoroutine(InvincibleCO(time));
    }

    private IEnumerator InvincibleCO(float time)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_spriteRenderer.DOFade(0, time/5).SetLoops(-1, LoopType.Yoyo));
        
        _collider.enabled = false;
        yield return new WaitForSeconds(time);
        seq.Kill();
        _collider.enabled = true;
        _spriteRenderer.color = Color.white;
    }
}
