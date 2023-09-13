using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRock : MonoBehaviour
{
    private GameObject particle;
    private GameObject particle1;
    void Start()
    {
        particle = transform.GetChild(0).gameObject;
        particle1 = transform.GetChild(1).gameObject;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particle.SetActive(true);
            particle.transform.parent = null;
            particle1.SetActive(true);
            particle1.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
