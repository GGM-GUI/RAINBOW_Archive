using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire1Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(2);
        }
    }
}
