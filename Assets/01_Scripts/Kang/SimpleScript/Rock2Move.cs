using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2Move : MonoBehaviour
{
    [SerializeField] private float speed;
    float time = 0;
    [SerializeField] private Sprite[] sprites;
    private Transform bossTrm;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
        bossTrm = GameObject.Find("GreenBoss").transform;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(2);
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 16)
        {
            transform.up = -(bossTrm.position - transform.position);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, BossNormalMove.me.position) < 0.7f)
            {
                Destroy(gameObject);
            }
        }
    }
}
