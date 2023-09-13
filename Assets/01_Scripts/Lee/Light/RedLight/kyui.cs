using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyui : MonoBehaviour
{
    public bool isPushing = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPushing = true;
        }
    }
}
