using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject particle;
    private Transform player;
    bool isMove = true;
    public PaletteUI Palette;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
}
    private void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(MoveStop());
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.7f);
        while (isMove == true)
        {
            yield return new WaitForSeconds(0.01f);
            transform.up = player.transform.position - transform.position;
        }
    }
    IEnumerator MoveStop()
    {
        yield return new WaitForSeconds(5f);
        isMove = false;
        speed = 0;
        yield return new WaitForSeconds(0.3f);
        speed = 10;
        Destroy(gameObject, 3f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(5);
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
