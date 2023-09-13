using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    InteractionTrigger _trigger;
    Rigidbody2D _rigid;

    public float moveSpeed = 0f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); 
        _trigger = GetComponentInChildren<InteractionTrigger>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 newVector =  new Vector3(x, y, 0);

        _rigid.MovePosition(transform.position + newVector.normalized * moveSpeed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            _trigger.TriggerEvent();
        }*/
    }
}
