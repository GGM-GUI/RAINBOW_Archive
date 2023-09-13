using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlockLight : MonoBehaviour
{
    private Transform redBlock;
    void Start()
    {
        redBlock = GameObject.Find("RedBlock").transform;
    }

    void Update()
    {
        transform.position = redBlock.transform.position;
    }
}
