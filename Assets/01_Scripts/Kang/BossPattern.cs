using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    public GameObject rock;
    public GameObject rock2;
    public GameObject bigRock;
    public GameObject FallowRock;
    int n = 1;
    private void OnEnable()
    {
        StartCoroutine($"Pattern{Random.Range(1, 5)}");
    }
    IEnumerator Pattern1()
    {
        yield return new WaitForSeconds(1);
        for(int i = 0; i < 30; i++)
        {
            Instantiate(rock, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            yield return new WaitForSeconds(0.3f);
        }
        gameObject.GetComponent<BossNormalMove>().enabled = true;
        enabled = false;
    }
    IEnumerator Pattern2()
    {
        yield return new WaitForSeconds(1);
        List<HingeJoint2D> list = new List<HingeJoint2D>();
        HingeJoint2D centerhj = Instantiate(rock2, transform.position, Quaternion.Euler(0, 0, 0)).AddComponent<HingeJoint2D>();
        list.Add(centerhj);
        HingeJoint2D l = centerhj;
        HingeJoint2D r = centerhj;
        for (int i = 1; i <= 14; i++)
        {
            HingeJoint2D hj = Instantiate(rock2, transform.position + new Vector3(i == 0? 3 : i * 0.6f, 0, 0), Quaternion.Euler(0, 0, 0)).AddComponent<HingeJoint2D>();
            hj.connectedBody = r.GetComponent<Rigidbody2D>();
            hj.useLimits = true;
            hj.limits = new JointAngleLimits2D { min = -25, max = 25 };
            list.Add(hj);
            r = hj;

            HingeJoint2D hj2 = Instantiate(rock2, transform.position + new Vector3(i == 0 ? -3 : i * -0.6f, 0, 0), Quaternion.Euler(0, 0, 0)).AddComponent<HingeJoint2D>();
            hj2.connectedBody = l.GetComponent<Rigidbody2D>();
            hj2.useLimits = true;
            hj2.limits = new JointAngleLimits2D { min = -25, max = 25 };
            list.Add(hj2);
            l = hj2;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2);
        centerhj.gameObject.AddComponent<ConstantForce2D>().torque = 35000;
        yield return new WaitForSeconds(9);

        for(int i = 0; i < list.Count; i++)
        {
            list[i].breakForce = 0;
        }
        yield return new WaitForSeconds(5);

        gameObject.GetComponent<BossNormalMove>().enabled = true;
        enabled = false;
    }
    IEnumerator Pattern3()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(bigRock, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<BossNormalMove>().enabled = true;
        enabled = false;
    }
    IEnumerator Pattern4()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(FallowRock, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(8);
        gameObject.GetComponent<BossNormalMove>().enabled = true;
        enabled = false;
    }
}
