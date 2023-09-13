using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YMBSpawn : InteractionAble
{
    [SerializeField] private GameObject thisGameOJ;

    WireSpawner wireSpawner;
    LifeBarMovement lifeBarMovement;

    private void Start()
    {
        wireSpawner = FindObjectOfType<WireSpawner>();
        lifeBarMovement = FindObjectOfType<LifeBarMovement>();
    }

    public override void InteractionEnter()
    {
        base.InteractionEnter();
        Debug.Log("중간 보스 등장");

        lifeBarMovement.LifeDownMove();
        wireSpawner.StartWireSpawn();
        Destroy(thisGameOJ);

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
