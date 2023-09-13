using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBotton : InteractionAble
{
    public bool isPushing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPushing = true;
        }
    }
}
