using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornStartDelayTime : MonoBehaviour
{
    [SerializeField] private float delays;
    Animator anim;
    [SerializeField] private bool randomStart;
    void Start()
    {
        if (randomStart)
        {
            delays = Random.Range(0, 5);
        }
        anim = GetComponent<Animator>();
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(delays);
        anim.enabled = true;
    }
}
