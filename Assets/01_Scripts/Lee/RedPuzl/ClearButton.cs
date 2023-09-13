using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    [SerializeField] private GameObject acorn;
    private RedBlockLight redBlockLight;

    private void Start()
    {
        redBlockLight = FindObjectOfType<RedBlockLight>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RedBlock")
        {
            Instantiate(acorn, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(redBlockLight);
        }
    }
}
