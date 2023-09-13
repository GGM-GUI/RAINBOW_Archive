using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//gameObject.GetComponent<GameObject>().SetActive(!!gameObject.GetComponent<GameObject>().activeSelf);
public class rockMove : MonoBehaviour
{
    [SerializeField] private float speed;
    bool trg = false;
    bool end = false;
    [SerializeField] private GameObject particle;
    void Update()
    {
        if (trg == false)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if(end == true)
        {
            transform.up = -(BossNormalMove.me.position - transform.position);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, BossNormalMove.me.position) < 0.7f)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(particle, transform.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z));
            StartCoroutine("comeback");
        }
        else
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(1);
        }
    }
    IEnumerator comeback()
    {
        yield return new WaitForSeconds(0.02f);
        trg = true;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        end = true;
    }
}
