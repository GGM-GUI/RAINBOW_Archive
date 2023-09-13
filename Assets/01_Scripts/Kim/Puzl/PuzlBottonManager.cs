using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzlBottonManager : InteractionAble
{
    public static float clearCount;

    [SerializeField] private float clearNum;
    public int pushCount;

    private bool isStay = false;
    public bool isAcornSpawn = false;

    private ResetBotton resetButton;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        resetButton = FindObjectOfType<ResetBotton>();
    }
    private void Update()
    {
        if (clearCount == 3)
        {
            Debug.Log("¹® ¿­¸²");
            isAcornSpawn = true;
        }
        else if (clearCount == 1 && clearCount == 2)
        {
            Debug.Log("¹® ´ÝÈû");
        }

        if (resetButton.isPushing == true)
        {
            pushCount = 0;
            clearCount = 0;
            animator.SetInteger("isCount", 0);
            Debug.Log("¸®¼Â");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        resetButton.isPushing = false;

        if (isStay == false && collision.tag == ("Player"))
        {
            if (pushCount == 10)
            {
                pushCount = 1;
                animator.SetInteger("isCount", 1);
            }
            else if (pushCount != 10)
            {
                pushCount++;
                Debug.Log(pushCount);
            }

            if (pushCount == clearNum)
            {
                clearCount++;
            }
            else if (pushCount == clearNum + 1)
            {
                clearCount--;
            }
            isStay = true;
            animator.SetInteger("isCount", pushCount);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isStay = false;
        }
    }
}
