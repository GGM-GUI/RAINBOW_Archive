using System;
using System.Collections;
using UnityEngine;

public class TreeMonster_Red : MonoBehaviour, IDamageable
{
    public float attackRange = 5f;
    public float attackDelay = 2f;

    public float appearDelay = 1f;

    public float blinkDuration = 0.2f;
    public float blinkInterval = 0.1f;

    public float hp = 10;

    private Transform player;
    private Animator animator;

    MonsterManager monsterManager;

    private bool isBlinking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        monsterManager = GetComponent<MonsterManager>();

        StartCoroutine(SpawnMonster());
    }

    private void Update()
    {
        if (!isBlinking && Vector3.Distance(transform.position, player.position) < attackRange)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
            transform.LookAt(player.position);
        }
    }

    private IEnumerator SpawnMonster()
    {
        while (true)
        {
            StartCoroutine(BlinkCoroutine());

            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);

            yield return new WaitForSeconds(appearDelay);

            isBlinking = false;
            gameObject.SetActive(true);
        }
    }

    private IEnumerator BlinkCoroutine()
    {
        isBlinking = true;
        float timer = 0f;
        while (timer < blinkDuration)
        {
            //gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);
            gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval * 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        monsterManager.Die();
    }
}
