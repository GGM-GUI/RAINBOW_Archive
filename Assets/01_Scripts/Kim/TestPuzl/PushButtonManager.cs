using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonManager : MonoBehaviour
{
    [SerializeField] private int clearNum;
    public static int clearCount;
    private int pushCount;

    private bool isStay = false;
    public bool isAcoreSpawn = false;

    ResetButtonTest _resetButtonTest;

    void Start()
    {
        _resetButtonTest = FindObjectOfType<ResetButtonTest>();
    }
    void Update()
    {
        if (clearCount == 3)
        {
            isAcoreSpawn = true;
            Debug.Log("¹® ¿­¸²");
        }
        else
        {
            Debug.Log("¹® ´ÝÈû");
        }

        if (_resetButtonTest.isReset == true)
        {
            clearCount = 0;
            pushCount = 0;
            Debug.Log("¸®¼Â");
        }

        Debug.Log(pushCount);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _resetButtonTest.isReset = false;

        if (isStay == false)
        {
            if (pushCount == 10)
            {
                pushCount = 1;
            }
            else if (pushCount != 10)
            {
                pushCount++;
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
    }
}
