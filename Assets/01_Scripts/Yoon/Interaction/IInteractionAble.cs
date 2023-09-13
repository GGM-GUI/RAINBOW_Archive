using System;
using UnityEngine;

public class InteractionAble : MonoBehaviour
{
    public Action EndCallbackAction = null; // �̺�Ʈ

    public virtual void InteractionEnter()
    {
        // Debug.Log("InteractionAble : InteractionEnter");

        GameManager.Instance.UpdateState(GameState.STANDBY);
    }

    // �Ű��������� �ʼ���, action�� using system �߰�
    public virtual void InteractionEnd(Action endCallback = null)
    {
        // Debug.Log("InteractionAble : InteractionEnd");

        EndCallbackAction?.Invoke();
        GameManager.Instance.UpdateState(GameState.RUNNING);
    }

    public virtual void InteractionExit()
    {
        // Debug.Log("InteractionAble : InteractionExit");
    }
}
