using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OramgeBullet : MonoBehaviour
{
    private Transform player;
    public static int Rotation = -20;
    private float speed = 8;
    private float MoveSin;
    private float MoveSinCount = 8;
    private float HighAndLow = 0;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        transform.up = player.transform.position - transform.position;
        if (Rotation == 40)
        {
            Rotation = -20;
        }
        transform.rotation *= Quaternion.Euler(0, 0, Rotation);
        Rotation += 20;
        if (Rotation == 0)
        {
            HighAndLow = 0f;
        }
    }
    private void Update()
    {
        if (HighAndLow < 3)
        {
            HighAndLow += 0.005f;
        }
        MoveSin += Time.deltaTime * MoveSinCount;
        if (gameObject.name == "MainSKillBullet")
        {
            this.transform.Translate(new Vector3(Mathf.Cos(MoveSin) * HighAndLow, 0, 0) * Time.deltaTime * speed);
        }
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
}
