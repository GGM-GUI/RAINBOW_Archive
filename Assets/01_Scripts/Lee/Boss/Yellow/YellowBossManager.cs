using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class YellowBossManager : MonoBehaviour
{
    private Transform player = null;
    private GameObject yellowBossVisual = null;
    private Animator _animator;

    private PaletteUI palette;
    private PlayerHPUI palette2;

    [SerializeField] private GameObject energeBall;
    [SerializeField] private GameObject energeBallBounse;
    [SerializeField] private GameObject lZTower;
    [SerializeField] private GameObject turnBall;
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    int BossSkillCount = 1;
    private float speed;

    private void Awake()
    {
        palette = FindObjectOfType<PaletteUI>();
        palette2 = FindObjectOfType<PlayerHPUI>();
        player = GameObject.Find("Player").transform;
        yellowBossVisual = GameObject.Find("YellowBossVisual").gameObject;
        _animator = yellowBossVisual.GetComponent<Animator>();
    }
    void Start()
    {
        BossPatton();
    }

    void Update()
    {
        yellowBossVisual.transform.position = transform.position;
        transform.up = player.transform.position - transform.position;

        if (LifeUpdate.isDie == true && LifeUpdate.dieCount == 3)
        {
            palette.CollisionMarble(AgentAttackState.YEOLLOW);
            palette2.CollisionMarble(AgentAttackState.YEOLLOW);
            Destroy(transform.root.gameObject);
        }
    }

    private void BossPatton()
    {
        switch (BossSkillCount)
        {
            case 1:
                StartCoroutine(Skill01());
                break;
            case 2:
                StartCoroutine(Skill02());
                break;
            case 3:
                Skill03();
                break;
            case 4:
                StartCoroutine(Movement());
                break;
        }
    }

    private IEnumerator Movement()
    {
        _animator.SetInteger("isSkillStarting", 1);
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        yield return new WaitForSeconds(2.7f);
        Vector3 savePoint = player.transform.position;
        yield return new WaitForSeconds(0.3f);
        transform.position = savePoint;
        _animator.SetInteger("isSkillStarting", 2);
        light1.SetActive(true);
        light2.SetActive(true);
        light3.SetActive(true);
        BossSkillCount = 1;
        yield return new WaitForSeconds(0.1f);
        _animator.SetInteger("isSkillStarting", 0);
        yield return new WaitForSeconds(3f);
        BossPatton();
    }

    private void Skill03()
    {
        StartCoroutine(BossSkill());
    }

    private IEnumerator Skill01()
    {
        _animator.SetInteger("isSkillStarting", 4);
        yield return new WaitForSeconds(1.4f);
        _animator.SetInteger("isSkillStarting", 0);
        int angle = 0;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(energeBallBounse, transform.position, Quaternion.Euler(0, 0, angle));
            angle += 90;
        }
        BossSkillCount++;
        yield return new WaitForSeconds(5f);
        BossPatton();
    }

    IEnumerator Skill02()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z);
            Instantiate(lZTower, pos, Quaternion.identity);
        }
        BossSkillCount++;
        yield return new WaitForSeconds(5f);
        BossPatton();
    }

    IEnumerator BossSkill()
    {
        _animator.SetInteger("isSkillStarting", 3);
        yield return new WaitForSeconds(1f); 
        _animator.SetInteger("isSkillStarting", 0);
        for (int i = 0; i< 8; i++)
        {
            Instantiate(turnBall, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
        BossSkillCount++;
        yield return new WaitForSeconds(10f);
        BossPatton();
    }
}
