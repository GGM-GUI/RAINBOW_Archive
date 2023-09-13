using UnityEngine;
using System;

public class DialogActing : InteractionAble
{
    [SerializeField] private string id = "";

    public override void InteractionEnter()
    {
        base.InteractionEnter();

        DialogManager.Instance.DialogPanelOn(id);

        InteractionEnd();
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd();
    }

    public override void InteractionExit()
    {
        base.InteractionExit();
        DialogManager.Instance.DialogPanelOff();
    }
}
