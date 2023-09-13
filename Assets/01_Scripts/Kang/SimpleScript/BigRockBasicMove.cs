using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRockBasicMove : MonoBehaviour
{
    [SerializeField] private float speed;
    bool trg = false;
    bool end = false;
    public GameObject rock;
    void Update()
    {
        if (trg == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (end == true)
        {
            transform.right = -(transform.position - BossNormalMove.me.position);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, BossNormalMove.me.position) < 0.7f)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            StartCoroutine("comeback");
        }
        else
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
    IEnumerator comeback()
    {
        yield return new WaitForSeconds(0);
        for (int i = -60; i <= 60; i += 60)
        {
            Transform t = Instantiate(rock, transform.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z - 90 + i)).transform;
            t.Translate(Vector3.down * 1f);
        }
        trg = true;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        end = true;
    }
}
