using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpike : MonoBehaviour
{
    [SerializeField] private float collectDuration = 2f;
    [SerializeField] private float launchForce = 10f;

    private Vector3 startPosition;
    private Transform playerTransform;
    public MonsterType monsterType;

    public void Launch(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        startPosition = transform.position;

        StartCoroutine(LaunchSpikesRoutine());
    }

    private IEnumerator LaunchSpikesRoutine()
    {
        float startTime = Time.time;
        float journeyDuration = collectDuration;

        while (Time.time < startTime + journeyDuration)
        {
            float fraction = (Time.time - startTime) / journeyDuration;
            transform.position = Vector3.Lerp(startPosition, playerTransform.position, fraction);
            yield return null;
        }

        // 발사되면 플레이어 쪽으로 발사
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * launchForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(monsterType.monstersList[1].attackDamage);
        }

        Destroy(gameObject);
    }
}
