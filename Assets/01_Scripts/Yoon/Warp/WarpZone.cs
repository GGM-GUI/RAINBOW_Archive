using System;
using System.Collections;
using UnityEngine;

public class WarpZone : InteractionAble
{
    private Transform player;
    public Transform targetTr;

    private void Start()
    {
        player = AgentController.Instance.PlayerTrm;
    }

    public override void InteractionEnter()
    {
        base.InteractionEnter();

        SceneChanger.Instance.DissolveOnOff();
        DelayMethod();

        InteractionEnd();   
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }

    public void WarpPosition()
    {
        player.position = targetTr.position;
    }

    private void DelayMethod()
    {
        StartCoroutine(DelayCoru());
    }

    IEnumerator DelayCoru()
    {
        yield return new WaitForSeconds(1f);
        WarpPosition();
    }
}
