using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLZMoveMent : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
    }
    [SerializeField] private float speed;
    private void Update()
    {
        if (YellowLZRotation.YellowLZReset == true)
        {
            transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x + speed, transform.localScale.y, transform.localScale.z);
        }
        
    }
}
