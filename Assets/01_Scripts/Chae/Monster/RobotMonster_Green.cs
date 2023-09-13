using UnityEngine;

public class RobotMonster_Green : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float fireInterval = 3f;
    [SerializeField] private float speed = 2f;

    private Transform playerTransform;
    private float lastFireTime = 0f;

    private Animator animator;
    public MonsterType monsterType;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector3 playerDirection = playerTransform.position - transform.position;
            playerDirection.z = 0f;
            playerDirection.Normalize();
            transform.position += playerDirection * speed * Time.deltaTime;
            WatchPlayer(playerDirection);
            if (Time.time - lastFireTime >= fireInterval)
            {
                MonsterInfo monsterInfo = monsterType.monstersList[0];
                Fire(playerDirection, monsterInfo);
                lastFireTime = Time.time;
            }
        }
    }
    private void WatchPlayer(Vector3 playerDirection)
    {
        if (playerDirection.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            transform.localScale = new Vector3(1f, 1f, 1f); // 원래 방향으로 설정
    }
    private void Fire(Vector3 playerDirection, MonsterInfo monsterInfo)
    {
        // 플레이어의 방향에 따라 로봇의 방향을 설정
        WatchPlayer(playerDirection);
        
        animator.SetTrigger("RobotFire");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AgentHP agentHP = collision.transform.GetComponentInChildren<AgentHP>();
        if (agentHP != null)
        {
            agentHP.AgentAttacked(monsterType.monstersList[0].hp);
        }
    }
}
