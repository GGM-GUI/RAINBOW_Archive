using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArrow : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.Translate(Vector2.down * 100);
        }
    }
}
