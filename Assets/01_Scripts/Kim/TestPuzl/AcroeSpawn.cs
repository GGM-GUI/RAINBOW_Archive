using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcroeSpawn : MonoBehaviour
{
    public GameObject _acore;
    PushButtonManager _pushCM;
    void Start()
    {
        _pushCM = FindObjectOfType<PushButtonManager>();
    }
    void Update()
    {
        if (_pushCM.isAcoreSpawn == true)
        {
            Instantiate(_acore, transform.position, Quaternion.identity);
        }
    }
}
