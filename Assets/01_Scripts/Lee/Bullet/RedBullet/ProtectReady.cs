using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectReady : MonoBehaviour
{
    private GameObject Boss = null;
    private void Awake()
    {
        Boss = GameObject.Find("BossRogic").gameObject;
    }
    void Update()
    {
        Pos();
    }
    private void Pos()
    {
        transform.position = new Vector3(Boss.transform.position.x, Boss.transform.position.y - 0.5f, Boss.transform.position.z);
        Destroy(gameObject, 2f);
    }
}
