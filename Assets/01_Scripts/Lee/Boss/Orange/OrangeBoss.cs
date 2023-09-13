using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrangeBoss : MonoBehaviour
{
    private Transform player;
    [SerializeField] 
    private float avoidDistance = 7;
    [SerializeField] 
    private float followDistance = 8;
    [SerializeField] 
    private float speed = 1.5f;
    [SerializeField]
    private GameObject orangeSkillBulletA;
    [SerializeField]
    private GameObject orangeSkillBulletB;
    [SerializeField]
    private GameObject orangeSkillBulletC;
    private int skillCount;
    
    int BossSklillUseCount = 0;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        
    }

    void Start()
    {
        skillCount = 2;
        StartCoroutine(Stay());
    }

    private void Update()
    {
        if (LifeUpdate.isDie == true && LifeUpdate.dieCount == 2)
        {
            LifeUpdate.isDie = false;
            Destroy(gameObject);
        }
    }
    IEnumerator Stay()
    {
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(OrangeBossPatton());
    }
    IEnumerator OrangeBossMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            transform.up = transform.position - player.transform.position;
            //보스로부터 플레이어의 거리가 avoidDistance보다 가까이 있다면 뒤로 이동한다.
            if (Vector3.Distance(transform.position, player.position) > avoidDistance)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }

            //보스로부터 플레이어의 거리가 followDistance보다 멀다면 앞으로 이동한다.
            else if (Vector3.Distance(transform.position, player.position) < avoidDistance && Vector3.Distance(transform.position, player.position) < followDistance)
            {
                transform.Translate(Vector3.up.normalized * Time.deltaTime * (speed - 0.5f));
            }
        }
    }

    IEnumerator OrangeBossAttack()
    {
        for (int j = 1; j <= 3; j++)
        {
            StartCoroutine("OrangeBossMovement");
            yield return new WaitForSeconds(1f);

            StopCoroutine("OrangeBossMovement");
            yield return new WaitForSeconds(0.3f);

            for (int i = 1; i <= 3; i++)
            {
                if (i == 2)
                {
                    Instantiate(orangeSkillBulletA, transform.position, Quaternion.identity).gameObject.name = "MainSKillBullet";
                }
                else
                {
                    Instantiate(orangeSkillBulletA, transform.position, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(1.3f);
        int Rotation = -45;
        for (int k = 1; k <= 8; k++)
        {
            Instantiate(orangeSkillBulletB, transform.position, Quaternion.Euler(0, 0, Rotation));
            Rotation += 45;
        }
        PattenStart();
    }
    private void PattenStart()
    {
        skillCount = 0;
        StartCoroutine(OrangeBossPatton());
    }

    IEnumerator OrangeBossPatton()
    {
        switch (skillCount)
        {
            case 1:
                StopCoroutine("OrangeBossMovement");

                StartCoroutine(OrangeBossAttack());
                break;

            case 2:
                StopCoroutine("OrangeBossMovement");

                StartCoroutine(OrangeBossSkillB());
                break;

            case 3:
                StartCoroutine(OrangeBossSkillC());
                break;

            case 0:
                yield return new WaitForSeconds(0.3f);
                StartCoroutine("OrangeBossMovement");

                yield return new WaitForSeconds(3f);
                BossSklillUseCount += 1;
                skillCount = BossSklillUseCount;
                StartCoroutine(OrangeBossPatton());
                break;
        }
    }

    IEnumerator OrangeBossSkillB()
    {
        Sequence seq = DOTween.Sequence();
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1);
            transform.up = player.transform.position - transform.position;
            Vector3 targetPos = player.transform.position;

            seq.Append(transform.DOShakePosition(duration: 0.5f, vibrato: 20, strength: 0.1f));

            seq.Append(transform.DOMove(targetPos, 1).SetEase(Ease.InCubic));
            yield return new WaitForSeconds(2);
        }
        PattenStart();
        StopCoroutine("OrangeBossSkillB");
    }
    IEnumerator OrangeBossSkillC()
    {
        for(int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(orangeSkillBulletC, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(20f);
        BossSklillUseCount = 0;
        PattenStart();
        StopCoroutine("OrangeBossSkillC");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
}
