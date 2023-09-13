using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMainBSpawn : InteractionAble
{
    public GameObject thisGameOJ;
    public GameObject mainBossPrefab;

    LifeBarMovement lifeBarMovement;

    private void Start()
    {
        lifeBarMovement = FindObjectOfType<LifeBarMovement>();
    }

    public override void InteractionEnter()
    {
        base.InteractionEnter();
        Debug.Log("���� ���� ����");

        lifeBarMovement.LifeDownMove();
        Instantiate(mainBossPrefab, transform.position, Quaternion.identity);
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
