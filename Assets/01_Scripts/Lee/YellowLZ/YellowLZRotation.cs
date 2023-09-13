using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLZRotation : MonoBehaviour
{
    bool YellowLZDie = false;
    [SerializeField] private GameObject Volt;
    [SerializeField] private GameObject DieGameObject;
    Animator animator;
    [SerializeField] private GameObject yellowBossVisual;
    private Transform player;
    static public bool YellowLZReset = false;
    [SerializeField] private GameObject Readly;
    // Start is called before the first frame update
    void Start()
    {
        animator = yellowBossVisual.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        StartCoroutine(LZAttackDelay());
        StartCoroutine(DieEnvent());
        YellowLZReset = true;
    }

    IEnumerator LZAttackDelay()
    {
        
        yield return new WaitForSeconds(2f);
        while (true)
        {
            {
                if (YellowLZDie == false)
                {
                    transform.up = player.transform.position - transform.position;
                    yield return new WaitForSeconds(0.1f);
                    animator.SetInteger("isLZManager", 1);
                    yield return new WaitForSeconds(0.5f);
                    YellowLZReset = false;
                    yield return new WaitForSeconds(1f);
                    YellowLZReset = true;
                    yield return new WaitForSeconds(3f);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    IEnumerator Lightning()
    {
        StopCoroutine("LZAttackDelay");
        YellowLZDie = true;
        animator.SetInteger("isLZManager", 2);
        yield return new WaitForSeconds(0.5f);
        Instantiate(Volt, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
        Destroy(DieGameObject);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    IEnumerator DieEnvent()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(Lightning());
    }

}
