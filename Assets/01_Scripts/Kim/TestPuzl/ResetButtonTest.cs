using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonTest : MonoBehaviour
{
    public bool isReset = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isReset = true;
        }
    }
}
