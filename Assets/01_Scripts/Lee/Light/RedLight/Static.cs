using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{
    private float pushCount;
    public static float clearCount;
    private bool isStay = false;
    [SerializeField] private float clearNum;

    private void Update()
    {
        if (clearCount == 3)
        {
            Debug.Log("¹® ¿­¸²");
        }
        else
        {
            Debug.Log("¹® ´ÝÈû");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStay == false)
        {

            if (collision.tag == "Player")
            {
                pushCount++;
            }

            if (pushCount == clearNum /* 7 */)
            {
                clearCount++;
            }
            else if(pushCount == clearNum + 1 /* 8 */)
            {
                clearCount--;
            }
            isStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
    }
}
