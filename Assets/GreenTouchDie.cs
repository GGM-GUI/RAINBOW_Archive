using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTouchDie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "DieTile")
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            transform.position += (transform.position - pos).normalized * 0.2f;
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        AgentController.Instance.Invincible(2);
        yield return new WaitForSeconds(2f);
    }
}
