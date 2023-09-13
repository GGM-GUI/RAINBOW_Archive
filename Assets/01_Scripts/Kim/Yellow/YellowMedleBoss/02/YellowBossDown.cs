using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class YellowBossDown : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private int avoidDistance = 10;
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject centerPoint;
    private int bossBigDownCount = 0;

    WireSpawner wireSpawner;
    Animator animator;
    Tweener tweener;
    BoxCollider2D collider2D;
    IEnumerator enumerator;

    private void Start()
    {
        enumerator = BossDown(); // �ڷ�ƾ ����
        player = GameObject.Find("Player");// �±׷� ��������
        animator = GetComponent<Animator>();
        //player = AgentController.Instance.PlayerTrm.gameObject; // �÷��̾� ��ġ ��������
        wireSpawner = FindObjectOfType<WireSpawner>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    public void StartBossDown()
    {
        StartCoroutine(enumerator);
    }

    public IEnumerator BossDown()
    {
        Debug.Log("BossDown ����");
        animator.SetBool("BossAttack", true);
        collider2D.enabled = false;

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(player.transform.position, 2.0f, false).SetEase(Ease.OutQuart);

        yield return new WaitForSeconds(1f);
        CameraShake.Instance.Shake(1f, 7f);
        collider2D.enabled = true;
        yield return new WaitForSeconds(1f);

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(point.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
        collider2D.enabled = false;

        yield return new WaitForSeconds(1f);
        animator.SetBool("BossAttack", false);
        yield return new WaitForSeconds(1f);




        animator.SetBool("BossAttack", true);
        collider2D.enabled = false;

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(player.transform.position, 2.0f, false).SetEase(Ease.OutQuart);

        yield return new WaitForSeconds(1f);
        CameraShake.Instance.Shake(1f, 7f);
        collider2D.enabled = true;
        yield return new WaitForSeconds(1f);

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(point.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
        collider2D.enabled = false;

        yield return new WaitForSeconds(1f);
        animator.SetBool("BossAttack", false);
        yield return new WaitForSeconds(1f);





        animator.SetBool("BossAttack", true);
        collider2D.enabled = false;

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(player.transform.position, 2.0f, false).SetEase(Ease.OutQuart);

        yield return new WaitForSeconds(1f);
        collider2D.enabled = true;
        CameraShake.Instance.Shake(1f, 7f);
        yield return new WaitForSeconds(1f);

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(point.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
        collider2D.enabled = false;

        yield return new WaitForSeconds(1f);
        animator.SetBool("BossAttack", false);
        yield return new WaitForSeconds(1f);





        animator.SetBool("BossAttack", true);
        collider2D.enabled = false;

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(player.transform.position, 2.0f, false).SetEase(Ease.OutQuart);

        yield return new WaitForSeconds(1f);
        CameraShake.Instance.Shake(1f, 7f);
        collider2D.enabled = true;
        yield return new WaitForSeconds(1f);

        if (tweener != null && tweener.IsPlaying())
        {
            tweener.Kill();
        }
        tweener = transform.DOMove(point.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
        collider2D.enabled = false;

        yield return new WaitForSeconds(1f);
        animator.SetBool("BossAttack", false);

        //���ͷ� ��������
        yield return new WaitForSeconds(2f);
        tweener = transform.DOMove(centerPoint.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
        animator.SetBool("BossRight", true);
        yield return new WaitForSeconds(1f);
        CameraShake.Instance.Shake(1f, 7f);
        collider2D.enabled = true;

        StartCoroutine(BossBigDown());
    }

    IEnumerator BossBigDown()
    {
        while (true)
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= 1.7f)
            {
                Debug.Log("��ǥ �ȿ� ����");
                animator.SetBool("BossRight", false);
                yield return new WaitForSeconds(1f);
                transform.DOScale(3f, 3f); // ũ�� Ű���

                yield return new WaitForSeconds(2f);
                animator.SetBool("BossUp", true);

                if (tweener != null && tweener.IsPlaying())
                {
                    tweener.Kill();
                }
                tweener = transform.DOMove(new Vector3(transform.position.x, point.transform.position.y, 0f), 1.5f, false).SetEase(Ease.OutQuart);
                collider2D.enabled = false;

                yield return new WaitForSeconds(1f);

                if (tweener != null && tweener.IsPlaying())
                {
                    tweener.Kill();
                }
                tweener = transform.DOMove(player.transform.position, 2.0f, false).SetEase(Ease.OutQuart);

                yield return new WaitForSeconds(0.8f);
                collider2D.enabled = true;
                CameraShake.Instance.Shake(1f, 7.5f);
                yield return new WaitForSeconds(0.2f);
                transform.DOScale(1f, 2f); // ũ�� ���̱�
                yield return new WaitForSeconds(2f);
                animator.SetBool("BossUp", false);
                animator.SetBool("BossRight", true);

                bossBigDownCount++;
                Debug.Log("ī��Ʈ ����");
            }
            yield return null;

            if (bossBigDownCount == 3)
            {
                bossBigDownCount = 0;
                transform.DOMove(point.transform.position, 1.5f, false).SetEase(Ease.OutQuart);
                collider2D.enabled = false;
                animator.SetBool("BossRight", false);
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(wireSpawner.WireSpawn());
                break;
            }
            yield return null;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3); // ����
        }
    }
}
