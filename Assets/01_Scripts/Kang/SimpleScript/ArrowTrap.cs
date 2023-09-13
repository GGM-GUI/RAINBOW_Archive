using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    private GameObject arrow;
    private Transform startPos;
    private Transform endPos;
    [SerializeField] float speed = 10;
    void Start()
    {
        arrow = transform.GetChild(0).gameObject;
        startPos = transform.GetChild(1);
        endPos = transform.GetChild(2);
    }
    public void Update()
    {
        if (arrow.transform.localPosition.y <= endPos.localPosition.y)
        {
            arrow.SetActive(false);
        }
        else
        {
            arrow.transform.Translate(Vector2.down * Time.deltaTime * 10);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (arrow.activeSelf == false)
            {
                arrow.transform.localPosition = new Vector3(0, startPos.localPosition.y, speed);
                arrow.SetActive(true);
            }
        }
    }
}
