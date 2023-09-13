using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject particle;
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        transform.up = player.transform.position - transform.position;
    }

    void Update()
    {
        MoveController();
    }
    private void MoveController()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Wall")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "PlayerBrush")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
