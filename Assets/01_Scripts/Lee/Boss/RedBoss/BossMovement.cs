using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float StayTime;
    [SerializeField] private int control;
    [SerializeField] private GameObject FireBall;
    [SerializeField] private GameObject FireBaby;
    [SerializeField] private GameObject Clone;
    [SerializeField] private GameObject ProtectReadly;
    [SerializeField] private GameObject Protect;
    [SerializeField] private GameObject Danger;
    bool SkillController = false;
    private Transform player;
    private Transform boss = null;
    Animator animator = null ;
    public bool BossStage = false;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        boss = GameObject.Find("BossVisual").transform;
        animator = GameObject.Find("BossVisual").GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(StageStart());
    }

    void Update()
    {








        if(BossStage == true)
        {
        BossRotation();
        BossController();
        }
    }
    IEnumerator StageStart()
    {
        yield return new WaitForSeconds(0.3f);
        BossStage = true;
        StartCoroutine("CoolTime");
    }

    private void BossRotation()
    {
        Vector3 pos = player.transform.position - transform.position;
        transform.up = pos.normalized;
        //Debug.Log(pos.normalized);
    }

    private void BossController()
    {
        switch (control)
        {
            case 1:
                transform.Translate(Vector3.up * speed * Time.deltaTime);

                break;

            case 2:
                if (SkillController == true)
                {
                    Skill01();
                }

                break;

            case 3:
                if (SkillController == true)
                {
                    Skill02();
                }

                break;

            case 4:
                if (SkillController == true)
                {
                    Skill03();
                }

                break;

        }
    }
    private void Skill01()
    {
        StartCoroutine("Skill01Attack");
    }

    private void Skill02()
    {
        StartCoroutine("Skill02Attack");
    }

    private void Skill03()
    {
        StartCoroutine("Skill03Attack");
    }

    IEnumerator CoolTime()
    {
        control = 1;

        yield return new WaitForSeconds(StayTime);
        control = Random.Range(2, 5);

        SkillController = true;
    }

    IEnumerator Skill01Attack()
    {
        SkillController = false;

        int FireBallRotation = 0;

        for (int i = 0; i < 8; i++)
        {
            Instantiate(Danger, transform.position, Quaternion.Euler(0, 0, FireBallRotation));
            FireBallRotation += 45;
        }
        yield return new WaitForSeconds(0.7f);

        animator.SetBool("FireBall", true);
        yield return new WaitForSeconds(0.5f);

        FireBallRotation = 0;

        for(int i = 0; i < 8; i++)
        {
        Instantiate(FireBall, transform.position, Quaternion.Euler(0, 0, FireBallRotation));
        FireBallRotation += 45;
        }
        yield return new WaitForSeconds(1f);
        animator.SetBool("FireBall", false);
        StartCoroutine(CoolTime());
    }

    IEnumerator Skill02Attack()
    {
        SkillController = false;
        animator.SetBool("MobSpawn", true);
        yield return new WaitForSeconds(0.3f);

        int FireBallRotation = 45;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(FireBaby, transform.position, Quaternion.Euler(0, 0, FireBallRotation));
            FireBallRotation += 90;
        }
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("MobSpawn", false);
        StartCoroutine(CoolTime());
    }

    IEnumerator Skill03Attack()
    {
        SkillController = false;
        int distance = 3;
        int FireBallRotation = 45;
        Vector3 scale = boss.transform.localScale;
        yield return new WaitForSeconds(0.3f);

        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            Instantiate(ProtectReadly, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Instantiate(Protect, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1f);

            StartCoroutine(CoolTime());
        }

        else if (Vector3.Distance(transform.position, player.position) > distance)
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);

                scale.x -= 0.1f;
                scale.y -= 0.1f;
                boss.transform.localScale = scale;

                if (scale.x <= 1 || scale.y <= 1)
                {
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Clone, transform.position, Quaternion.Euler(0, 0, FireBallRotation));
                FireBallRotation += 90;
            }
            yield return new WaitForSeconds(10f);

            StartCoroutine(CoolTime());
        }
    }
}
