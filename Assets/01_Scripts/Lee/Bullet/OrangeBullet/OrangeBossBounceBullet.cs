using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBossBounceBullet : MonoBehaviour
{
    private float speed = 10f;
    public static int Rotation = -20;
    private Transform player;
    int count = 0;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Start()
    {
        transform.up = player.transform.position - transform.position;
        if (Rotation == 40)
        {
            Rotation = -20;
        }
        transform.rotation *= Quaternion.Euler(0, 0, Rotation);
        Rotation += 20;
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.up = player.transform.position - transform.position;
            count += 1;
            if (count == 2)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(5);
        }
    }
}
