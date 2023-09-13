using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
}
