using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossSwithRed : InteractionAble
{
    public GameObject RedBoss;
    public GameObject BossBar;
    private void Start()
    {
        //Palette = GameObject.Find("Palette").GetComponent<PaletteUI>();
    }
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        InteractionEnd(() =>
        {
            BossBar.SetActive(true);
            RedBoss.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        });
    }

    public override void InteractionEnd(Action endCallback = null)
    {
        EndCallbackAction = endCallback;
        base.InteractionEnd(endCallback);
    }
}
