using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float stopTime = 3;
    [SerializeField] private GameObject CloneFireBall;
    private GameObject boss = null;
    bool isMove = true;

    void Start()
    {
        boss = GameObject.Find("BossVisual").gameObject;
        StartCoroutine("Movement");
    }

    IEnumerator Movement()
    {
        while (true)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(stopTime);
        if(isMove == true)
        {
            StartCoroutine(Attack());
        }
        StopCoroutine("Movement");
        isMove = false;
    }

    IEnumerator Scale()
    {
        yield return new WaitForSeconds(2f);
        Vector3 scale = boss.transform.localScale;

        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            scale.x += 0.1f;
            scale.y += 0.1f;
            boss.transform.localScale = scale;

            if (scale.x >= 1.5 || scale.y >= 1.5)
            {
                break;
            }
        }
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(CloneFireBall, transform.position, Quaternion.identity);
        }

        transform.up = boss.transform.position - transform.position;

        isMove = true;
        StartCoroutine(Scale());
        StartCoroutine(Movement());
        Destroy(gameObject, stopTime);
    }
}
