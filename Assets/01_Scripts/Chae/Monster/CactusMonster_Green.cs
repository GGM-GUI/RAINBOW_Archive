using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMonster_Green : MonoBehaviour
{
    // 망가짐     방학때 고쳐줌

    [SerializeField] private GameObject spikesGroupPrefab;
    [SerializeField] private List<Transform> spikeSpawnPoints;
    [SerializeField] private float spikesLaunchInterval = 0.5f;
    [SerializeField] private float nextMoveTime = 4f;
    [SerializeField] private float detectionRange = 3f;

    private Vector3 moveDirection;
    private List<GameObject> spikesGroups = new List<GameObject>(); // 가시 그룹들을 관리할 리스트

    public MonsterType monsterType;
    private Transform playerTransform;

    private bool isSpikesLaunching = false;
    private bool isMoving = true;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        foreach (Transform spawnPoint in spikeSpawnPoints)
        {
            SpawnSpikes(spawnPoint.position);
        }


        StartCoroutine(DisableSpikes());
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // 플레이어가 일정 범위 안에 있는지 확인
        if (distanceToPlayer <= detectionRange)
        {
            // 플레이어가 일정 범위 안에 있을 때 가시 발사 실행
            LaunchSpikes();
        }

        // 선인장 움직임 처리
        if (isMoving)
        {
            Move();
        }
    }

    private void CalculateNextMoveDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        if (Mathf.Abs(randomX) > Mathf.Abs(randomY))
        {
            randomY = 0f;
        }
        else
        {
            randomX = 0f;
        }

        moveDirection = new Vector3(randomX, randomY, 0f).normalized;
    }

    private void Move()
    {
        if (Time.time >= nextMoveTime)
        {
            // 새로운 방향을 계산하여 설정
            CalculateNextMoveDirection();

            // 다음 움직임까지의 딜레이 설정
            nextMoveTime = Time.time + Random.Range(1f, 4f);
        }

        // 이동 속도를 ScriptableObject에서 가져옴
        float movementSpeed = monsterType.monstersList[0].movementSpeed;

        // 몬스터를 설정된 방향으로 이동
        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        // 몬스터의 방향에 따라 좌우 반전
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void SpawnSpikes(Vector3 spawnPosition)
    {
        GameObject newSpikesGroup = Instantiate(spikesGroupPrefab, spawnPosition, Quaternion.identity);
        newSpikesGroup.SetActive(false); 

        spikesGroups.Add(newSpikesGroup); 
    }

    private IEnumerator DisableSpikes()
    {
        yield return new WaitForSeconds(spikesLaunchInterval);

        // 가시들을 다시 비활성화하는 코드
        foreach (GameObject spikeGroup in spikesGroups)
        {
            spikeGroup.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            spikeGroup.SetActive(false);
        }

        isSpikesLaunching = false;
    }

    private void LaunchSpikes()
    {
        if (!isSpikesLaunching)
        {
            foreach (GameObject spikesGroup in spikesGroups)
            {
                // 오브젝트가 비활성화된 경우 무시
                if (spikesGroup == null || !spikesGroup.activeSelf)
                    continue;

                CactusSpike[] spikes = spikesGroup.GetComponentsInChildren<CactusSpike>();
                foreach (var spike in spikes)
                {
                    // 스크립트 컴포넌트가 이미 파괴된 경우 무시
                    if (spike == null)
                        continue;

                    spike.gameObject.SetActive(true);
                    spike.Launch(playerTransform);
                }
            }

            isSpikesLaunching = true;
        }
    }
}
