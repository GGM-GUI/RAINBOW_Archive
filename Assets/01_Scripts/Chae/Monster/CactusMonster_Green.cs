using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMonster_Green : MonoBehaviour
{
    // ������     ���ж� ������

    [SerializeField] private GameObject spikesGroupPrefab;
    [SerializeField] private List<Transform> spikeSpawnPoints;
    [SerializeField] private float spikesLaunchInterval = 0.5f;
    [SerializeField] private float nextMoveTime = 4f;
    [SerializeField] private float detectionRange = 3f;

    private Vector3 moveDirection;
    private List<GameObject> spikesGroups = new List<GameObject>(); // ���� �׷���� ������ ����Ʈ

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

        // �÷��̾ ���� ���� �ȿ� �ִ��� Ȯ��
        if (distanceToPlayer <= detectionRange)
        {
            // �÷��̾ ���� ���� �ȿ� ���� �� ���� �߻� ����
            LaunchSpikes();
        }

        // ������ ������ ó��
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
            // ���ο� ������ ����Ͽ� ����
            CalculateNextMoveDirection();

            // ���� �����ӱ����� ������ ����
            nextMoveTime = Time.time + Random.Range(1f, 4f);
        }

        // �̵� �ӵ��� ScriptableObject���� ������
        float movementSpeed = monsterType.monstersList[0].movementSpeed;

        // ���͸� ������ �������� �̵�
        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        // ������ ���⿡ ���� �¿� ����
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

        // ���õ��� �ٽ� ��Ȱ��ȭ�ϴ� �ڵ�
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
                // ������Ʈ�� ��Ȱ��ȭ�� ��� ����
                if (spikesGroup == null || !spikesGroup.activeSelf)
                    continue;

                CactusSpike[] spikes = spikesGroup.GetComponentsInChildren<CactusSpike>();
                foreach (var spike in spikes)
                {
                    // ��ũ��Ʈ ������Ʈ�� �̹� �ı��� ��� ����
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
