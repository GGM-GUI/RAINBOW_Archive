using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject particle;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 2);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(10);
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
