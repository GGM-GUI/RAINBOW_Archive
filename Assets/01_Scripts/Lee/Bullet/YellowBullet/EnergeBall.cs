using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeBall : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform Player;
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = Player.transform.position - transform.position;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(5);
        }
    }
}
