using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeBallBounse : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed;
    private Animator animator;
    int Count = 0;
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(Count >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BounseAnimation()
    {
        animator.SetBool("isBounsing", true);
        yield return new WaitForSeconds(0.1f);
        transform.up = player.transform.position - transform.position;
        animator.SetBool("isBounsing", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine(BounseAnimation());
            Count++;
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
}
