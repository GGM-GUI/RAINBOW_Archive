using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallTurn : MonoBehaviour
{
    float circle = 0;
    bool circleRotation = true;
    private GameObject yellowBoss;
    void Start()
    {
        yellowBoss = GameObject.Find("YellowBossCollison").gameObject;
        StartCoroutine(Die());
        StartCoroutine(MovingSinCos());
    }

    IEnumerator MovingSinCos()
    {
        while (true)
        {
            for (int th = 2; th < 360; th += 3)
            {
                circle += 0.0025f;
                var rad = Mathf.Deg2Rad * th;
                var x = circle * Mathf.Sin(rad);
                var y = circle * Mathf.Cos(rad);
                this.transform.position = new Vector2(yellowBoss.transform.position.x + x, yellowBoss.transform.position.y + y);
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
            for (int th = 2; th < 360; th += 3)
            {
                circle += 0.0001f;
                var rad = Mathf.Deg2Rad * th;
                var x = circle * Mathf.Sin(rad);
                var y = circle * Mathf.Cos(rad);
                this.transform.position = new Vector2(yellowBoss.transform.position.x + x, yellowBoss.transform.position.y + y);
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
