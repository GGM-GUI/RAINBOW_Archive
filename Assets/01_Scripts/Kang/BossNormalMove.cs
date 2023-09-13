using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public enum State : short
{
    FOLLOW = 0,
    ATTACK = 1
}
public class BossNormalMove : MonoBehaviour
{
    public Transform player;
    public static State bossState;
    float time = 0;
    bool onX = false;
    [SerializeField]private float speed;
    private VisualEffect trace;
    public static Transform me;
    private BossPattern bossPattern;
    public bool isPen = false;
    int count = 0;
    private void Awake()
    {
        me = transform;
        bossPattern = GetComponent<BossPattern>();
    }
    private void OnEnable()
    {
        trace = transform.Find("trace").GetComponent<VisualEffect>();
        StopAllCoroutines();
        StartCoroutine(NormalMove(0));
    }
    IEnumerator NormalMove(int c)
    {
        bossState = State.FOLLOW;
        for (int i = c; i < 4; i++)
        {
            count = i;
            yield return new WaitForSeconds(2f);

            trace.Play();
            while (Mathf.Abs(transform.position.y - player.position.y) > 0.2f)
            {
                MoveY(player.position.y);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            ShakeManager.Instance.Shake(0, 3);
            yield return new WaitForSeconds(0.25f);

            while (Mathf.Abs(transform.position.x - player.position.x) > 0.2f)
            {
                MoveX(player.position.x);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            ShakeManager.Instance.Shake(0, 3);
            trace.Stop();
        }
        yield return new WaitForSeconds(2f);
        trace.Play();
        while (Mathf.Abs(transform.position.y + 75.57f) > 0.2f)
        {
            MoveY(-75.57f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        ShakeManager.Instance.Shake(0, 3);
        yield return new WaitForSeconds(0.25f);
        while (Mathf.Abs(transform.position.x - 68.478f) > 0.2f)
        {
            MoveX(68.478f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        ShakeManager.Instance.Shake(0, 3);
        trace.Stop();
        bossState = State.ATTACK;
        bossPattern.enabled = true;
        enabled = false;
    }
    private void MoveX(float target)
    {
        if (transform.position.x > target)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (transform.position.x < target)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void MoveY(float target)
    {
        if (transform.position.y > target)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (transform.position.y < target)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (bossState == State.FOLLOW)
            {
                collision.transform.position += (collision.transform.position - transform.position).normalized * 2f;
                collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);
                collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(2);
                StopAllCoroutines();
                StartCoroutine(NormalMove(count + 1));
            }
        }
    }
    public void StopAll()
    {
        StopCoroutine(NormalMove(0));
        enabled = false;
    }
}
