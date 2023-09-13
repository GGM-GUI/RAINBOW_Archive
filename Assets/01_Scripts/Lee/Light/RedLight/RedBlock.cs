using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    private Vector3 startPos;
    private void Start()
    {
        startPos = this.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sss");
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = startPos;
        }
    }
}
