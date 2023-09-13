using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySample : InteractionAble
{
    public GameObject particle;
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        DoorKeyManager.Instance.getKeyNum += 1;
        Instantiate(particle, transform.position, Quaternion.identity);
        InteractionEnd(() =>
        {
            transform.parent.gameObject.SetActive(false);
        });
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }
}
