using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        Vector3 sc = transform.localScale;
        float c = 0.1f;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sc.x += c + 0.1f;

            transform.Translate(new Vector3(c, 0, 0));
            transform.localScale = sc;
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
