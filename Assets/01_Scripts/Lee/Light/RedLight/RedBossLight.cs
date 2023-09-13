using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBossLight : MonoBehaviour
{
    private GameObject boss = null;
    void Start()
    {
        boss = GameObject.Find("BossVisual").gameObject;
    }

    void Update()
    {
        if(boss != null)
        transform.position = boss.transform.position;
    }
}
