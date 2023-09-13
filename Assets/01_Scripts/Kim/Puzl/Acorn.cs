using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : InteractionAble
{
    public static int ACOCount;
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        InteractionEnd(() =>
        {
            Debug.Log("���丮 ȹ��");
            ACOCount++;
            Destroy(gameObject);
        });
        
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }
}
