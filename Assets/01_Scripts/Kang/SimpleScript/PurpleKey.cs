using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleKey : InteractionAble
{
    private Animator anim;
    bool isKey = false;
    public GameObject warp;
    public GameObject key;
    private void Start()
    {
        if(transform.root.gameObject.name == "Key")
        {
            isKey = true;
        }
        else
        {
            anim = transform.parent.gameObject.GetComponent<Animator>();
        }
    }
    public override void InteractionEnter()
    {
        base.InteractionEnter();
        Debug.Log("dkasjfd");
        if(isKey == true)
        {
            key.SetActive(false);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            if(key.activeSelf == false)
            {
                anim.SetTrigger("Open");
                warp.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
