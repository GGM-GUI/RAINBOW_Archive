using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowRock : MonoBehaviour
{
    float time = 0;
    public float speed;
    public GameObject rock;
    bool trg = false;
    bool end = false;
    private void Start()
    {
        GetComponent<ConstantForce2D>().relativeForce = new Vector2(0, Random.Range(-8, -12f));
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.6f)
        {
            transform.up = transform.position - AgentController.Instance.PlayerTrm.position;
            transform.rotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            StartCoroutine("comeback");
        }
        else
        {
            collision.transform.GetComponentInParent<AgentHP>().AgentAttacked(3);
        }
    }
    IEnumerator comeback()
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i <= 360; i += 90)
        {
            Transform t = Instantiate(rock, transform.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z + i)).transform;
            t.Translate(Vector3.down * 0.5f);
        }
        Destroy(gameObject);
    }
}
