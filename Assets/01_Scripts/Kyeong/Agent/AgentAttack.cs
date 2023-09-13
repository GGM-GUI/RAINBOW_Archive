using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour, IAgentComponent
{
    [SerializeField] private List<Vector3> _atkPos;
    [SerializeField] private List<Vector3> _atkRot;
    [SerializeField] private List<AttackSO> _atkSO;
    public bool IsAttack = false;
    private int _rotationNum = 0;

    private Transform _playerTrm;
    
    [Header("Animation")]
    private Animator _animator;
    private List<int> _animationHash = new List<int>();

    [SerializeField] private List<GameObject> _attackBullet;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerTrm = transform.root.transform;
        AddAnimationHash();
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
        AgentInput.Instance.OnAttackKeyPress += Attack;
        AgentInput.Instance.OnMovementKeyPress += AttackPos;
    }

    public void UnInit()
    {
        AgentInput.Instance.OnAttackKeyPress -= Attack;
        AgentInput.Instance.OnMovementKeyPress -= AttackPos;
    }

    #endregion

    #region ??????¡Æ? ???? ???????? ??? ?????¡Æ? 
    
    public void AttackPos(Vector2 pos)
    {
        if (pos == Vector2.zero)
            return;
        else if (pos == Vector2.up)
            AttackPosChange(0);
        else if (pos == Vector2.left)
            AttackPosChange(1);
        else if (pos == Vector2.right)
            AttackPosChange(2);
        else if (pos == Vector2.down)
            AttackPosChange(3);
    }

    private void AttackPosChange(int num)
    {
        if (IsAttack)
            return;

        _rotationNum = num;
        transform.localPosition = _atkPos[num];
        transform.rotation = Quaternion.Euler(_atkRot[num]);
    }
    
    #endregion

    private void AddAnimationHash()
    {
        _animationHash.Add(Animator.StringToHash("GRAY"));
        _animationHash.Add(Animator.StringToHash("RED"));
        _animationHash.Add(Animator.StringToHash("YELLOW"));
        _animationHash.Add(Animator.StringToHash("GREEN"));
        _animationHash.Add(Animator.StringToHash("BLUE"));
        _animationHash.Add(Animator.StringToHash("PURPLE"));
    }
    
    public void Attack()
    {
        PlayerAttack(AgentController.Instance.AttackState);
    }

    private void PlayerAttack(AgentAttackState atkState)
    {
        if (IsAttack)
            return;
        IsAttack = true;
        _animator.SetTrigger(_animationHash[(int)atkState]);

        switch (atkState)
        {
            case AgentAttackState.RED:
            case AgentAttackState.YEOLLOW:
            case AgentAttackState.GREEN:
                AttackProjectile(atkState);
                break;
        }
    }

    public void PlayerAttackEnd()
    {
        IsAttack = false;
    }

    public void AttackProjectile(AgentAttackState atkState)
    {
        GameObject projectile = Instantiate(_attackBullet[(int)atkState], transform.position, Quaternion.Euler(0, 0, _atkRot[_rotationNum].z + 90f));
        projectile.GetComponent<IProjectile>().Init(2);
    }
}

// ???? ??? ????????
// ??????? 
