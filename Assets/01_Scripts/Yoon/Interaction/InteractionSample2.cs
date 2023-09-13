using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionSample2 : InteractionAble
{
    private bool isMove = false;

    public override void InteractionEnter()
    {
        base.InteractionEnter();

        if (!isMove)
        {
            transform.parent.position = new Vector3(5, 0, 0);
            isMove = true;
        }
        else
        {
            transform.parent.position = new Vector3(0, 0, 0);
            isMove = false;
        }

        // 끝나고 해줄 일이 없으면 굳이 매개변수 안 넣어줘도 돼
        InteractionEnd();
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd();
    }
}
