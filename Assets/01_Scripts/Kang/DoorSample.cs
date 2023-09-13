using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSample : InteractionAble
{
    private Animator anim;
    bool trg = false;
    private void Awake()
    {
        anim = transform.parent.gameObject.GetComponent<Animator>();
    }
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        if (DoorKeyManager.Instance.getKeyNum > 0 && trg == false)
        {
            trg = true;
            anim.SetTrigger("Open");
            DoorKeyManager.Instance.getKeyNum -= 1;
        }
        InteractionEnd(() => {
        });
    }
    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }
}
