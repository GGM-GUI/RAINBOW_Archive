using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttackCollison : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _isAttack = false;
    
    private void OnEnable()
    {
        _isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ?��??? Enemy?��????? _isAttack == false???? ??????
        // ???? ?????? ???. 

        if (collision.gameObject.CompareTag("Mob") && !_isAttack) //?��? ???? ????????
        {
            switch (AgentController.Instance.AttackState)
            {
                case AgentAttackState.GRAY:
                    
                case AgentAttackState.RED:
                case AgentAttackState.YEOLLOW:
                case AgentAttackState.GREEN:
                case AgentAttackState.BLUE:
                case AgentAttackState.PURPLE:
                    break;
            }

            _isAttack = true;
        }
    }
}
