using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCircleBullet : MonoBehaviour
{
    float circle = 0;
    private Transform boss = null;
    bool circleRotation = true;
    private void Awake()
    {
        boss = GameObject.Find("OrangeBoss(Clone)").transform;
    }
    private void Start()
    {
        StartCoroutine(MovingSinCos());
        transform.position = boss.transform.position;
        StartCoroutine(Die());
    }
    IEnumerator MovingSinCos()
    {
        while (true)
        {
            for (int th = 2; th < 360; th++)
            {
                circle += 0.005f;
                var rad = Mathf.Deg2Rad * th;
                var x = circle * Mathf.Sin(rad);
                var y = circle * Mathf.Cos(rad);
                this.transform.position = new Vector2(boss.transform.position.x + x, boss.transform.position.y + y);
                yield return new WaitForSeconds(0.000000001f);
            }
            if (circleRotation != true)
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        while (true)
        {
            for (int th = 2; th < 360; th++)
            {
                circle -= 0.005f;
                var rad = Mathf.Deg2Rad * th;
                var x = circle * Mathf.Sin(rad);
                var y = circle * Mathf.Cos(rad);
                this.transform.position = new Vector2(boss.transform.position.x - x, boss.transform.position.y - y);
                yield return new WaitForSeconds(0.000000001f);
            }
        }
    }
            
    IEnumerator Die()
    {
        yield return new WaitForSeconds(10f);
        circleRotation = false;
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
}
