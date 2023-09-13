using UnityEngine;

public class InteractionTrigger : MonoBehaviour, IAgentComponent
{
    public InteractionAble nowTriggerObj = null;
    private bool isActing = false;

    #region IAgentComponent

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
        AgentInput.Instance.OnInteractionKeyPress += TriggerEvent;
    }

    public void UnInit()
    {
        AgentInput.Instance.OnInteractionKeyPress -= TriggerEvent;
    }

    #endregion

    // ��ȣ�ۿ� Ű�� ������ �� ����Ǵ� �Լ�
    public void TriggerEvent()
    {
        if (isActing) return;

        if (nowTriggerObj != null)
        {
            nowTriggerObj.InteractionEnter();
            //isActing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractionAble"))
        {
            InteractionAble interactionObj = collision.GetComponent<InteractionAble>();
            if (interactionObj != null)
            {
                nowTriggerObj = interactionObj;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractionAble"))
        {
            if (nowTriggerObj != null)
            {
                nowTriggerObj.InteractionExit();
                nowTriggerObj = null;

                // �� �Ʒ��� InteractionEnd���� �Ͼ�� ���־�� ��
                // isActing = false;
            }
        }
    }
}
