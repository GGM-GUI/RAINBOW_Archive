using System.Collections;
using UnityEngine;

public class PotionMonster_Orange : MonoBehaviour, IDamageable
{
    public MonsterType monsterType;

    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpDuration = 1f;
    [SerializeField] private AnimationCurve jumpCurve;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isJumping = false;
    private bool isBroken = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (!isBroken)
        {
            if (distanceToPlayer <= detectionRange && !isJumping)
            {
                JumpTowardsPlayer();
            }
        }
    }

    private void JumpTowardsPlayer()
    {
        // 포션 몬스터를 플레이어 방향으로 이동
        Vector3 playerDirection = playerTransform.position - transform.position;
        playerDirection.z = 0f;
        playerDirection.Normalize();

        // 방향에 따라 스프라이트를 뒤집음
        if (playerDirection.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // 점프 애니메이션 실행
        StartCoroutine(JumpAnimation(playerDirection));
    }

    private IEnumerator JumpAnimation(Vector3 direction)
    {
        isJumping = true;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + new Vector2(direction.x, 1f);

        float startTime = Time.time;
        float endTime = startTime + jumpDuration;

        while (Time.time < endTime)
        {
            float timeFraction = Mathf.InverseLerp(startTime, endTime, Time.time);
            float jumpHeight = jumpCurve.Evaluate(timeFraction);

            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, timeFraction);
            newPosition.y += jumpHeight * jumpForce * Time.deltaTime;

            rb.MovePosition(newPosition);

            yield return null;
        }

        // 점프 끝났을 때 플레이어 위치로 이동
        rb.MovePosition(new Vector2(playerTransform.position.x, transform.position.y));

        // Jump 애니메이션 재생 후 BrokenPotion 애니메이션 실행
        animator.SetTrigger("BrokenPotion");

        // 포션 몬스터가 사라짐
        Destroy(gameObject, 1f);
        isBroken = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(monsterType.monstersList[0].attackDamage);
    }

    public void TakeDamage(int damageAmount)
    {
        throw new System.NotImplementedException();
    }
}
