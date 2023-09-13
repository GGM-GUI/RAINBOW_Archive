using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireMonster_Red : MonoBehaviour, IDamageable
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float moveDelay = 5f;
    [SerializeField] private float explosionDelay = 3.0f;
    private float hp = 10;
    private float nextMoveTime = 0;
    private float range = 2.0f;

    private Vector3 direction;

    MonsterManager monsterManager;

    private bool playerFound = false;

    private Animator anim;
    public Transform player;
    private AudioSource audioSource;

    [SerializeField] private AudioClip clip;

    MonsterState _state = MonsterState.Move;

    void Start()
    {
        monsterManager = GetComponent<MonsterManager>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        player = FindObjectOfType<AgentController>().transform;
    }


    void Update()
    {
        switch (_state)
        {
            case MonsterState.Move:
                UpdateMove();
                break;
            case MonsterState.Explode:
                UpdateExplode();
                break;
        }
    }

    void UpdateMove()
    {
        if (!playerFound)
        {
            if (Time.time >= nextMoveTime)
            {
                float x = Random.Range(-1, 2);
                float y = Random.Range(-1, 2);

                if (x != 0 && y != 0) // 대각선 방향으로 이동하지 않도록 함
                {
                    x = 0;
                }

                direction = new Vector3(x, y, 0).normalized;
                nextMoveTime = Time.time + moveDelay;
            }
        }
        else
        {
            direction = (player.position - transform.position).normalized;
        }

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 0.5f))
        {
            if (hitInfo.collider.CompareTag("Wall"))
            {
                direction *= -1f;
            }
        }

        transform.position += direction * speed * Time.deltaTime;


        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            _state = MonsterState.Explode;
        }
    }

    private void UpdateExplode()
    {
        transform.DOScale(new Vector3(2, 2, 2), 0.5f);

        string animationName = (direction.x < 0f) ? "FireMabLeftExplosion" : "FireMabRightExplosion";

        anim.Play(animationName);
        audioSource.Play();


        Destroy(gameObject, explosionDelay);
    }


    public void Die()
    {
        Destroy(gameObject);
        monsterManager.Die();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateExplode();
        }
        else
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            if (Mathf.Abs(contactPoint.x - center.x) > Mathf.Abs(contactPoint.y - center.y))
            {
                direction.x *= -1;
            }
            else
            {
                direction.y *= -1;
            }
        }

    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            Die();
        }
    }
}