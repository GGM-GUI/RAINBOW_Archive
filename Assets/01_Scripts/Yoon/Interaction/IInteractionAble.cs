using System;
using UnityEngine;

public class InteractionAble : MonoBehaviour
{
    public Action EndCallbackAction = null; // 이벤트

    public virtual void InteractionEnter()
    {
        // Debug.Log("InteractionAble : InteractionEnter");

        GameManager.Instance.UpdateState(GameState.STANDBY);
    }

    // 매개변수까지 필수임, action은 using system 추가
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
